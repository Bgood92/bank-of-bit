using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using BankOfBIT.Models;
using System.IO;

namespace WindowsBankingApplication
{
    /// <summary>
    /// Batch class - Handles batch processing
    /// </summary>
    public class Batch
    {
        private string inputFileName;
        private string logFileName;
        private string logData;

        BankOfBITContext db = new BankOfBITContext();
        BankService.TransactionManagerClient transactionManager = new BankService.TransactionManagerClient();

        /// <summary>
        /// Processes all errors found within the current file being processed
        /// </summary>
        /// <param name="beforeQuery">The first query to evaluate</param>
        /// <param name="afterQuery">The second query to evaluate</param>
        /// <param name="message">The error message that will be written to the log file</param>
        private void processErrors(IEnumerable<XElement> beforeQuery, IEnumerable<XElement> afterQuery, string message)
        {
            IEnumerable<XElement> errors = beforeQuery.Except(afterQuery);

            foreach (XElement error in errors)
            {
                logData += string.Format("-------ERROR-------\n" +
                                            "File: {0}\n" +
                                            "Institution: {1}\n" +
                                            "Account Number: {2}\n" +
                                            "Transaction Type: {3}\n" +
                                            "Amount: {4}\n" +
                                            "Notes: {5}\n" +
                                            "Nodes: {6}\n" +
                                            "{7}\n" +
                                            "--------------------------\n\n",
                                            inputFileName, error.Element("institution"), error.Element("account_no"),
                                            error.Element("type"), error.Element("amount"), error.Element("notes"),
                                            error.Descendants().Count(), message);                          
            }            
        }

        /// <summary>
        /// Used to verify the attributes of the xml files's root element
        /// </summary>
        /// <returns>True if the root element is in a valid format</returns>
        private bool processHeader()
        {
            bool verified = true;
            XDocument xDocDetails = XDocument.Load(inputFileName);
            XElement singleElement = xDocDetails.Element("account_update");
            XAttribute checksumAttribute = singleElement.Attribute("checksum");
            IEnumerable<XElement> descendantNodes = singleElement.Descendants("transaction");
            IEnumerable<XElement> xAccountNoElements = descendantNodes.Descendants().Where(d => d.Name == "account_no");
            IEnumerable<int> institutionNumbers = db.Institutions.Select(x => x.InstituionNumber);
            
            long checksum = 0;

            foreach (XElement element in xAccountNoElements)
            {
                checksum += long.Parse(element.Value);
            }

            try
            {
                if (singleElement.Attributes().Count() < 3)
                {
                    verified = false;
                }
                else if (singleElement.Attribute("date").Value != DateTime.Now.ToShortDateString())
                {
                    verified = false;
                }

                if (verified == true)
                {
                    foreach (int inst in institutionNumbers)
                    {
                        if (!singleElement.Attribute("institution").Value.Equals(inst.ToString()))
                        {
                            verified = false;
                        }
                        else
                        {
                            verified = true;
                            break;
                        }
                    } 
                }

                if (!checksumAttribute.Value.Equals(checksum.ToString()))
                {
                    verified = false;
                }

                if (verified == false)
                {
                    throw new Exception("XML file's root element is not in the correct format.\n");                   
                }
            }
            catch (Exception e)
            {
                logData += e.Message;
            }

            return verified;
        }

        /// <summary>
        /// Used to verify the contents of the detail records in the input file
        /// </summary>
        private void processDetails()
        {
            //Grabs the whole document
            XDocument xDocDetails = XDocument.Load(inputFileName);

            //Grabs every <transaction> element and all its contents
            IEnumerable<XElement> transactionElements = xDocDetails.Descendants("transaction");

            //Only grab the transaction elements that have 5 child nodes
            IEnumerable<XElement> filteredElements = transactionElements.Where(d => d.Descendants().Count() == 5);

            processErrors(transactionElements, filteredElements, "Transaction node must have 5 child elements.");

            //Grabs the transaction elements with 5 child nodes whose institution number matches the institution
            //attribute of the root element
            IEnumerable<XElement> filteredElements2 = filteredElements.Where
                (d => d.Element("institution").Value == xDocDetails.Element("account_update").Attribute("institution").Value);

            processErrors(filteredElements, filteredElements2, "Institution node must match the institution attribute of the root element.");

            //Grabs the transaction elements with 5 child nodes whose institution number matches the institution
            //attribute of the root element and the type and amount nodes are numeric
            IEnumerable<XElement> filteredElements3 = filteredElements2.Where
                (d => Utility.Numeric.isNumeric(d.Element("type").Value, System.Globalization.NumberStyles.Any)).Where
                (d => Utility.Numeric.isNumeric(d.Element("amount").Value, System.Globalization.NumberStyles.Any));

            processErrors(filteredElements2, filteredElements3, "Type and amount nodes must numeric.");

            //Grabs the transaction elements with 5 child nodes whose institution number matches the institution
            //attribute of the root element, the type and amount nodes are numeric, and the type node equals 2 or 6
            IEnumerable<XElement> filteredElements4 = filteredElements3.Where
                (d => int.Parse(d.Element("type").Value) == 2 || int.Parse(d.Element("type").Value) == 6);

            processErrors(filteredElements3, filteredElements4, "Type node must have a value of 2 or 6.");

            IEnumerable<XElement> filteredElements5 = filteredElements4.Where
                (d => int.Parse(d.Element("type").Value) == 2 && int.Parse(d.Element("amount").Value) > 0
                    || int.Parse(d.Element("type").Value) == 6 && int.Parse(d.Element("amount").Value) == 0);

            processErrors(filteredElements4, filteredElements5, "If the type node has a value of 6, amount node must have a value of 0. " +
                            "If the type node has a value of 2, amount node must have a value greater than 0.");

            IEnumerable<long> accountNumbers = db.BankAccounts.Select(x => x.AccountNumber);

            IEnumerable<XElement> filteredElements6 = filteredElements5.Where(x => accountNumbers.Contains(long.Parse(x.Element("account_no").Value)));

            processErrors(filteredElements5, filteredElements6, "The value of account_no does not exist in the database.");

            processTransactions(filteredElements6);
        }

        /// <summary>
        /// Used to process all valid transaction records
        /// </summary>
        /// <param name="transactionRecords">The records to be processed</param>
        private void processTransactions(IEnumerable<XElement> transactionRecords)
        {
            foreach (XElement transaction in transactionRecords)
            {
                double? balance = 0;
                long accountNo = long.Parse(transaction.Element("account_no").Value);
                string transactionType = string.Empty;
                BankAccount account = db.BankAccounts.Where(x => x.AccountNumber == 
                    accountNo).SingleOrDefault();

                if (int.Parse(transaction.Element("type").Value) == 2)
                {
                    balance = transactionManager.Withdrawal(account.BankAccountId, double.Parse(transaction.Element("amount").Value),
                        transaction.Element("notes").Value);
                    transactionType = "Transaction Completed Successfully: Withdrawal $" + 
                        transaction.Element("amount").Value + " from account " + account.AccountNumber + "\n";
                }
                else if (int.Parse(transaction.Element("type").Value) == 6)
                {
                    balance = transactionManager.CalculateInterest(account.BankAccountId, transaction.Element("notes").Value);
                    transactionType = "Transaction Completed Successfully: Interest charged to account " 
                        + account.AccountNumber + "\n";
                }

                if (balance != null)
                {
                    logData += transactionType;
                }
            }
        }

        /// <summary>
        /// Writes the log data to a log file
        /// </summary>
        /// <returns>The captured log data</returns>
        public string WriteLogData()
        {
            if (File.Exists("COMPLETE-" + inputFileName))
            {
                File.Delete("COMPLETE-" + inputFileName);
            }

            if (File.Exists(inputFileName))
            {
                File.Move(inputFileName, "COMPLETE-" + inputFileName);
            }

            StreamWriter writer = new StreamWriter(logFileName);

            writer.Write(logData);
            writer.Close();

            string capturedLogData = logData;

            logData = logFileName = string.Empty;

            return capturedLogData;
        }

        /// <summary>
        /// Initiate the bank transmission process by determining the appropriate filenames
        /// </summary>
        /// <param name="institution">The institution number</param>
        /// <param name="key">The provided key</param>
        public void ProcessTransmission(string institution, string key)
        {
            inputFileName = string.Format("{0}-{1}-{2}.xml", DateTime.Now.Year, DateTime.Now.DayOfYear.ToString("000"), institution);          
            logFileName = string.Format("LOG {0}.txt", inputFileName.Substring(0, inputFileName.IndexOf(".xml")));
            string encryptedFileName = inputFileName + ".encrypted";
            bool success = false;

            if (File.Exists(encryptedFileName))
            {
                try
                {
                    Utility.Encryption.Decrypt(encryptedFileName, inputFileName, key);
                    success = true;
                }
                catch (Exception e)
                {
                    success = false;
                    logData += "\n" + e.Message + "\n";                    
                }
                
            }
            else
            {
                logData += "The encrypted file does not exist\n";
            }

            if (success == true)
            {
                if (!File.Exists(inputFileName))
                {
                    logData += inputFileName + " does not exist.\n";
                }
                else
                {
                    if (processHeader() == true)
                    {
                        processDetails();
                    }
                } 
            }
        }
    }
}
