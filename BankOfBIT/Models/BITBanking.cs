using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using Utility;
using System.Data;

namespace BankOfBIT.Models
{
#region AccountState

    /// <summary>
    /// AccountState class - represents account state table in the database
    /// </summary>
    public abstract class AccountState
    {
        protected static BankOfBITContext db = new BankOfBITContext();

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AccountStateId { get; set; }

        [Display(Name="Lower\nLimit")]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public double LowerLimit { get; set; }

        [Display(Name="Upper\nLimit")]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public double UpperLimit { get; set; }

        [Required]
        [Display(Name="Interest\nRate")]
        [DisplayFormat(DataFormatString="{0:p}", ApplyFormatInEditMode = false)]
        public double Rate { get; set; }

        [Display(Name="Account\nState")]
        public string Description 
        {
            get
            {
                //Calls the GetDescription from the Helper class to eliminate each character after the instance of the word "Account"
                return Helper.GetDescription("State", this);
            }
        }

        /// <summary>
        /// Implemented inside the subclasses to adjusts the Rate property 
        /// according to the bank account balance
        /// </summary>
        /// <param name="bankAccount">Evaluates the Balance property of BankAccount</param>
        /// <returns>A value of 0 because this method will only ever be invoked from the subclasses</returns>
        public virtual double RateAdjustment(BankAccount bankAccount)
        {
            return 0;
        }

        /// <summary>
        /// Implemented in the subclasses to check what the balance is and 
        /// change the account state based on that value
        /// </summary>
        /// <param name="bankAccount">Evaluates bankAccount.balance</param>
        public virtual void StateChangeCheck(BankAccount bankAccount)
        {

        }
    }

#endregion

#region AccountStateSubClasses

    /// <summary>
    /// BronzeState class - represents bronze state table in the database
    /// </summary>
    public class BronzeState : AccountState
    {
        private const double LOWER_LIMIT = 0;
        private const double UPPER_LIMIT = 5000;
        private const double RATE = 0.01;

        private static BronzeState bronzeState;

        /// <summary>
        /// BronzeState constructor - Sets the Lower Limit, Upper Limit, and Rate of the Account State
        /// </summary>
        private BronzeState() 
        {
            LowerLimit = LOWER_LIMIT;
            UpperLimit = UPPER_LIMIT;
            Rate = RATE;
        }

        /// <summary>
        /// Returns an instance of the BronzeState
        /// </summary>
        /// <returns>bronzeState</returns>
        public static BronzeState GetInstance()
        {
            //Checks if there is already an instance of BronzeState
            if (bronzeState == null)
            {
                //Retrieves the instance of BronzeState from the BronzeStates table or null
                bronzeState = db.BronzeStates.SingleOrDefault();

                if (bronzeState == null)
                {
                    //Creates a new BronzeState object and adds it to the database
                    //Save changes to the database
                    bronzeState = new BronzeState();
                    db.BronzeStates.Add(bronzeState);
                    db.SaveChanges();
                }
            }
            return bronzeState;
        }

        /// <summary>
        /// Adjusts the Rate property according to the bank account balance
        /// </summary>
        /// <param name="bankAccount">Evaluates the Balance property of BankAccount</param>
        /// <returns>this.Rate</returns>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            double newRate = RATE;

            if (bankAccount.Balance <= LOWER_LIMIT)
            {
                newRate = 0.055;
            }
            return newRate;
        }

        /// <summary>
        /// Checks if the balance is greater than the upper limit - If so, change the state to silver
        /// </summary>
        /// <param name="bankAccount">Evaluates bankAccount.balance</param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (!bankAccount.Description.Equals("Mortgage")) //Check to see if the bank account is not a Mortgage account
            {
                if (bankAccount.Balance > UPPER_LIMIT)
                {
                    //Set bankAccount's AccountStateId equal to the GoldState's AccountStateId field
                    //if the balance is greater than the UPPER_LIMIT of this instance
                    bankAccount.AccountStateId = SilverState.GetInstance().AccountStateId;
                }
            }
        }
    }

    /// <summary>
    /// SilverState class - represents the silver state table in the database
    /// </summary>
    public class SilverState : AccountState
    {
        private const double LOWER_LIMIT = 5000;
        private const double UPPER_LIMIT = 10000;
        private const double RATE = 0.0125;

        private static SilverState silverState;

        /// <summary>
        /// SilverState constructor - Sets the Lower Limit, Upper Limit, and Rate of the Account State
        /// </summary>
        private SilverState() 
        {
            LowerLimit = LOWER_LIMIT;
            UpperLimit = UPPER_LIMIT;
            Rate = RATE;
        }

        /// <summary>
        /// Returns an instance of the SilverState
        /// </summary>
        /// <returns>SilverState</returns>
        public static SilverState GetInstance()
        {
            //Checks if there is already an instance of SilverState
            if (silverState == null)
            {
                //Retrieves the instance of SilverState from the SilverStates table or null
                silverState = db.SilverStates.SingleOrDefault();

                if (silverState == null)
                {
                    //Creates a new SilverState object and adds it to the database
                    //Save changes to the database
                    silverState = new SilverState();
                    db.SilverStates.Add(silverState);
                    db.SaveChanges();
                }
            }
            return silverState;
        }

        /// <summary>
        /// Returns the interest rate (Rate) for SilverState
        /// </summary>
        /// <param name="bankAccount">Evaluates the Balance property of BankAccount</param>
        /// <returns>this.Rate</returns>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            return RATE;
        }

        /// <summary>
        /// Checks if the balance is greater than the upper limit - If so, change the state to gold
        /// Checks if the balance is less than the lower limit - If so, change the state to bronze
        /// </summary>
        /// <param name="bankAccount">Evaluates the bankAccount.Balance</param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (!bankAccount.Description.Equals("Mortgage"))
            {
                if (bankAccount.Balance > UPPER_LIMIT)
                {
                    bankAccount.AccountStateId = GoldState.GetInstance().AccountStateId;
                }
                else if (bankAccount.Balance < LOWER_LIMIT)
                {
                    bankAccount.AccountStateId = BronzeState.GetInstance().AccountStateId;
                }
            }
        }
    }

    /// <summary>
    /// GoldState class - represents the gold state table in the database
    /// </summary>
    public class GoldState : AccountState
    {
        private const double LOWER_LIMIT = 10000;
        private const double UPPER_LIMIT = 20000;
        private const double RATE = 0.02;

        private static GoldState goldState;

        /// <summary>
        /// GoldState constructor - Sets the Lower Limit, Upper Limit, and Rate of the Account State
        /// </summary>
        private GoldState() 
        {
            LowerLimit = LOWER_LIMIT;
            UpperLimit = UPPER_LIMIT;
            Rate = RATE;
        }

        /// <summary>
        /// Returns an instance of the GoldState
        /// </summary>
        /// <returns>GoldState</returns>
        public static GoldState GetInstance()
        {
            if (goldState == null)
            {
                goldState = db.GoldStates.SingleOrDefault();

                if (goldState == null)
                {
                    goldState = new GoldState();
                    db.GoldStates.Add(goldState);
                    db.SaveChanges();
                }
            }
            return goldState;
        }

        /// <summary>
        /// Returns the interest rate (Rate) for GoldState
        /// </summary>
        /// <param name="bankAccount">Evaluates the DateCreated property of BankAccount</param>
        /// <returns>this.Rate</returns>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            double newRate = RATE;

            if (DateTime.Today.Year - bankAccount.DateCreated.Year >= 10)
            {
                newRate += .01;
            }

            return newRate;
        }

        /// <summary>
        /// Checks if the balance is greater than the upper limit - If so, change the state to Platinum
        /// Checks if the balance is less than the lower limit - If so, change the state to Silver
        /// </summary>
        /// <param name="bankAccount">Evaluates the bankAccount.Balance</param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (!bankAccount.Description.Equals("Mortgage"))
            {
                if (bankAccount.Balance > UPPER_LIMIT)
                {
                    bankAccount.AccountStateId = PlatinumState.GetInstance().AccountStateId;
                }
                else if (bankAccount.Balance < LOWER_LIMIT)
                {
                    bankAccount.AccountStateId = SilverState.GetInstance().AccountStateId;
                }
            }
        }
    }

    /// <summary>
    /// PlatinumState class - represents the platinum state table in the database
    /// </summary>
    public class PlatinumState : AccountState
    {
        private const double LOWER_LIMIT = 20000;
        private const double UPPER_LIMIT = 0;
        private const double RATE = 0.0250;

        private static PlatinumState platinumState;

        /// <summary>
        /// PlatinumState constructor - Sets the Lower Limit, Upper Limit, and Rate of the Account State
        /// </summary>
        private PlatinumState() 
        {
            LowerLimit = LOWER_LIMIT;
            UpperLimit = UPPER_LIMIT;
            Rate = RATE;
        }

        /// <summary>
        /// Returns an instance of the PlatinumState
        /// </summary>
        /// <returns>PlatinumState</returns>
        public static PlatinumState GetInstance()
        {
            if (platinumState == null)
            {
                platinumState = db.PlatinumStates.SingleOrDefault();

                if (platinumState == null)
                {
                    platinumState = new PlatinumState();
                    db.PlatinumStates.Add(platinumState);
                    db.SaveChanges();
                }
            }
            return platinumState;
        }

        /// <summary>
        /// Returns the interest rate (Rate) for PlatinumState
        /// </summary>
        /// <param name="bankAccount">Evaluates the DateCreated property of BankAccount</param>
        /// <returns>this.Rate</returns>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            double newRate = RATE;

            if (DateTime.Today.Year - bankAccount.DateCreated.Year >= 10)
            {
                newRate += 0.01;
            }
            if (bankAccount.Balance > bankAccount.Balance * 2)
            {
                newRate += 0.005;
            }
            return newRate;
        }

        /// <summary>
        /// Checks if the balance is less than the lower limit - If so, change the state to Gold
        /// </summary>
        /// <param name="bankAccount">Evaluates the bankAccount.Balance</param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (!bankAccount.Description.Equals("Mortgage"))
            {
                if (bankAccount.Balance < LOWER_LIMIT)
                {
                    bankAccount.AccountStateId = GoldState.GetInstance().AccountStateId;
                }
            }
        }
    }

#endregion

#region BankAccount

    /// <summary>
    /// BankAccount class - represents the bank account table in the database
    /// </summary>
    public abstract class BankAccount
    {
        protected static BankOfBITContext db = new BankOfBITContext();

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BankAccountId { get; set; }

        [Display(Name="Account\nNumber")]
        public long AccountNumber { get; set; }

        [Required]
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        [Required]
        [ForeignKey("AccountState")]
        public int AccountStateId { get; set; }

        [Required]
        [Display(Name="Current\nBalance")]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public double Balance { get; set; }

        [Required]
        [Display(Name="Opening\nBalance")]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public double OpeningBalance { get; set; }

        [Required]
        [Display(Name="Date\nCreated")]
        [DisplayFormat(DataFormatString="{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        [Display(Name="Account\nNotes")]
        public string Notes { get; set; }

        [Display(Name="Account\nType")]
        public string Description 
        {
            get
            {
                //Calls the GetDescription from the Helper class to eliminate each character after the instance of the word "Account"
                return Helper.GetDescription("Account", this);
            }
        }

        /// <summary>
        /// In each of the BankAccount subtypes, this code is implemented 
        /// to return the next account number
        /// </summary>
        public void SetNextAccountNumber()
        {
            
        }

        /// <summary>
        /// Changes the state of the bank account based on the current balance
        /// </summary>
        public void ChangeState()
        {
            bool matches = false;

            while (!matches)
            {
                foreach (AccountState state in db.AccountStates)
                {
                    if (this.AccountStateId == state.AccountStateId)
                    {
                        state.StateChangeCheck(this);

                        if (this.AccountStateId == state.AccountStateId)
                        {
                            matches = true;
                        }
                    }
                } 
            }
        }

        //Navigational properties
        public virtual Client Client { get; set; }
        public virtual AccountState AccountState { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }

#endregion

#region BankAccountSubClasses

    /// <summary>
    /// SavingsAccount class - represents the savings account table in the database
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        [Required]
        [Display(Name="Service\nCharges")]
        [DisplayFormat(DataFormatString="{0:c}", ApplyFormatInEditMode = false)] 
        public double SavingsServiceCharges { get; set; }

        /// <summary>
        /// Sets the next account number to the next incremented value
        /// </summary>
        public void SetNextAccountNumber()
        {
            this.AccountNumber = (long)StoredProcedures.NextNumber("NextSavingsAccounts");
        }
    }

    /// <summary>
    /// MortgageAccount class - represents the mortgage account table in the database
    /// </summary>
    public class MortgageAccount : BankAccount
    {
        [Required]
        [Display(Name="Interest\nRate")]
        [DisplayFormat(DataFormatString = "{0:p}", ApplyFormatInEditMode = false)]
        public double MortgageRate { get; set; }

        [Required]
        public int Amortization { get; set; }

        /// <summary>
        /// Sets the next account number to the next incremented value
        /// </summary>
        public void SetNextAccountNumber()
        {
            this.AccountNumber = (long)StoredProcedures.NextNumber("NextMortgageAccounts");
        }
    }

    /// <summary>
    /// InvestmentAccount - represents the investment account table in the database
    /// </summary>
    public class InvestmentAccount : BankAccount
    {
        [Required]
        [Display(Name = "Interest\nRate")]
        [DisplayFormat(DataFormatString = "{0:p}", ApplyFormatInEditMode = false)]
        public double InterestRate { get; set; }

        /// <summary>
        /// Sets the next account number to the next incremented value
        /// </summary>
        public void SetNextAccountNumber()
        {
            this.AccountNumber = (long)StoredProcedures.NextNumber("NextInvestmentAccounts");
        }
    }

    /// <summary>
    /// ChequingAccount class - represents the chequing account table in the database
    /// </summary>
    public class ChequingAccount : BankAccount
    {
        [Required]
        [Display(Name="Service\nCharges")]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)] 
        public double ChequingServiceCharges { get; set; }

        /// <summary>
        /// Sets the next account number to the next incremented value
        /// </summary>
        public void SetNextAccountNumber()
        {
            this.AccountNumber = (long)StoredProcedures.NextNumber("NextChequingAccounts");
        }
    }

#endregion

#region BankAccountAuxilaryClasses

    /// <summary>
    /// NextSavingsAccount class - represents the NextSavingsAccount table in the database
    /// </summary>
    public class NextSavingsAccount
    {
        private static NextSavingsAccount nextSavingsAccount;

        /// <summary>
        /// NextSavingsAccount constructor - sets initial values for the object
        /// </summary>
        private NextSavingsAccount() 
        {
            NextAvailableNumber = 20000;
        }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextSavingsAccountId { get; set; }

        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Returns an instance of NextSavingsAccount
        /// </summary>
        /// <returns>nextSavingsAccount</returns>
        public static NextSavingsAccount GetInstance()
        {
            BankOfBITContext db = new BankOfBITContext();

            if (nextSavingsAccount == null)
            {
                nextSavingsAccount = db.NextSavingsAccounts.SingleOrDefault();

                if (nextSavingsAccount == null)
                {
                    nextSavingsAccount = new NextSavingsAccount();
                    db.NextSavingsAccounts.Add(nextSavingsAccount);
                    db.SaveChanges();
                }
            }

            return nextSavingsAccount;
        }
    }

    /// <summary>
    /// NextChequingAccount class - represents the NextChequingAccount table in the database
    /// </summary>
    public class NextChequingAccount
    {
        private static NextChequingAccount nextChequingAccount;

        /// <summary>
        /// NextChequingAccount constructor - Sets initial values for the object
        /// </summary>
        private NextChequingAccount()
        {
            NextAvailableNumber = 20000000;
        }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextChequingAccountId { get; set; }

        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Returns an instance of NextChequingAccount
        /// </summary>
        /// <returns>nextChequingAccount</returns>
        public static NextChequingAccount GetInstance()
        {
            BankOfBITContext db = new BankOfBITContext();

            if (nextChequingAccount == null)
            {
                nextChequingAccount = db.NextChequingAccounts.SingleOrDefault();

                if (nextChequingAccount == null)
                {
                    nextChequingAccount = new NextChequingAccount();
                    db.NextChequingAccounts.Add(nextChequingAccount);
                    db.SaveChanges();
                }
            }

            return nextChequingAccount;
        }
    }

    /// <summary>
    /// NextMortgageAccount class - represents the NextMortgageAccount table in the database
    /// </summary>
    public class NextMortgageAccount
    {
        private static NextMortgageAccount nextMortgageAccount;

        /// <summary>
        /// NextMorgageAccount constructor - Sets initial values for the object
        /// </summary>
        private NextMortgageAccount()
        {
            NextAvailableNumber = 200000;
        }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextMortgageAccountId { get; set; }

        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Returns an instance of NextMortgageAccount
        /// </summary>
        /// <returns>nextMortgageAccount</returns>
        public static NextMortgageAccount GetInstance()
        {
            BankOfBITContext db = new BankOfBITContext();

            if (nextMortgageAccount == null)
            {
                nextMortgageAccount = db.NextMortgageAccounts.SingleOrDefault();

                if (nextMortgageAccount == null)
                {
                    nextMortgageAccount = new NextMortgageAccount();
                    db.NextMortgageAccounts.Add(nextMortgageAccount);
                    db.SaveChanges();
                }
            }

            return nextMortgageAccount;
        }
    }

    /// <summary>
    /// NextInvestmentAccount class - represents the NextInvestmentAccount table in teh database
    /// </summary>
    public class NextInvestmentAccount
    {
        private static NextInvestmentAccount nextInvestmentAccount;

        /// <summary>
        /// NextInvestmentAccount constructor - Sets initial values for the object
        /// </summary>
        private NextInvestmentAccount()
        {
            NextAvailableNumber = 2000000;
        }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextInvestmentAccountId { get; set; }

        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Returns an instance of NextInvestmentAccount
        /// </summary>
        /// <returns>nextInvestmentAccount</returns>
        public static NextInvestmentAccount GetInstance()
        {
            BankOfBITContext db = new BankOfBITContext();

            if (nextInvestmentAccount == null)
            {
                nextInvestmentAccount = db.NextInvestmentAccounts.SingleOrDefault();

                if (nextInvestmentAccount == null)
                {
                    nextInvestmentAccount = new NextInvestmentAccount();
                    db.NextInvestmentAccounts.Add(nextInvestmentAccount);
                    db.SaveChanges();
                }
            }

            return nextInvestmentAccount;
        }
    }

#endregion

#region Transaction

    /// <summary>
    /// Transaction class - represents the Transaction table in the database
    /// </summary>
    public class Transaction
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [Display(Name="Transaction\nNumber")]
        public long? TransactionNumber { get; set; }

        [Required]
        [ForeignKey("BankAccount")]
        public int BankAccountId { get; set; }

        [Required]
        [ForeignKey("TransactionType")]
        public int TransactionTypeId { get; set; }

        [Display(Name="Deposit")]
        public double Deposit { get; set; }

        [Display(Name = "Withdrawal")]
        public double Withdrawal { get; set; }

        [Required]
        [Display(Name="Date\nCreated")]
        [DisplayFormat(DataFormatString="{0:d}", ApplyFormatInEditMode=true)]
        public DateTime DateCreated { get; set; }

        [Display(Name="Notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Sets the next transaction number to the next incremented value
        /// </summary>
        public void SetNextTransactionNumber()
        {
            TransactionNumber = StoredProcedures.NextNumber("NextTransactionNumbers");
        }

        public virtual TransactionType TransactionType { get; set; }
        public virtual BankAccount BankAccount { get; set; }
    }

    #endregion

#region TransactionType

    /// <summary>
    /// TransactionType - represents the TransactionType table in the database
    /// </summary>
    public class TransactionType
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TransactionTypeId { get; set; }

        [Display(Name="Transaction\nType")]
        public string Description { get; set; }

        [Display(Name="Service\nCharges")]
        public double ServiceCharges { get; set; }
    }

    #endregion

#region NextTransactionNumber

    /// <summary>
    /// NextTransactionNumber - represents the NextTransactionNumber table in the database
    /// </summary>
    public class NextTransactionNumber
    {
        private static NextTransactionNumber nextTransactionNumber;

        /// <summary>
        /// Constructor for NextTransactionNumber - Sets initial values for the object
        /// </summary>
        private NextTransactionNumber()
        {
            NextAvailableNumber = 700;
        }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextTransactionNumberId { get; set; }

        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Returns an instance of NextTransactionNumber
        /// </summary>
        /// <returns>nextTransactionNumber</returns>
        public static NextTransactionNumber GetInstance()
        {
            BankOfBITContext db = new BankOfBITContext();

            if (nextTransactionNumber == null)
            {
                nextTransactionNumber = db.NextTransactionNumbers.SingleOrDefault();

                if (nextTransactionNumber == null)
                {
                    nextTransactionNumber = new NextTransactionNumber();
                    db.NextTransactionNumbers.Add(nextTransactionNumber);
                    db.SaveChanges();
                }
            }

            return nextTransactionNumber;
        }
    }

#endregion

#region Client

    /// <summary>
    /// Client class - represents the client table in the database
    /// </summary>
    public class Client
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        [Display(Name="Client")]
        public long? ClientNumber { get; set; }

        [Required]
        [StringLength(35, MinimumLength=1)]
        [Display(Name="First\nName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(35, MinimumLength=1)]
        [Display(Name="Last\nName")]
        public string LastName { get; set; }

        [Required]
        [StringLength(35, MinimumLength=1)]
        [Display(Name="Address")]
        public string Address { get; set; }

        [Required]
        [StringLength(35, MinimumLength=1)]
        [Display(Name="City")]
        public string City { get; set; }

        [Required]
        [RegularExpression("^(N[BLSTU]|[AMN]B|[BQ]C|ON|PE|SK)$", ErrorMessage = "A valid province code is required.")]
        public string Province { get; set; }

        [Required]
        [RegularExpression("[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]", 
                            ErrorMessage="A valid postal code is required")]
        [Display(Name="Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name="Date\nCreated")]
        [DisplayFormat(DataFormatString="{0:d}", ApplyFormatInEditMode= true)]
        public DateTime DateCreated { get; set; }

        [Display(Name="Client\nNotes")]
        public string Notes { get; set; }

        [Display(Name="Name")]
        public string FullName 
        { 
            get 
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        [Display(Name="Address")]
        public string FullAddress
        {
            get
            {
                return string.Format("{0} {1}, {2} {3}", Address, City, Province, PostalCode);
            }
        }

        /// <summary>
        /// Sets the next client number in the clients table to the next incremented value
        /// </summary>
        public void SetNextClientNumber()
        {
            ClientNumber = StoredProcedures.NextNumber("NextClientNumbers");
        }

        //Navigational properties
        public virtual ICollection<BankAccount> BankAccount { get; set; }
    }

#endregion

#region RFIDTag

    /// <summary>
    /// RFIDTag class - represents the RFIDTag table in the database
    /// </summary>
    public class RFIDTag
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RFIDTagId { get; set; }

        public long CardNumber { get; set; }
    
        [Required]
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }

#endregion

#region NextClientNumber

    /// <summary>
    /// NextClientNumber = represents the NextClientNumber table in the database
    /// </summary>
    public class NextClientNumber
    {
        private static NextClientNumber nextClientNumber;

        /// <summary>
        /// Constructor for NextClientNumber - Sets initial values for the object
        /// </summary>
        private NextClientNumber()
        {
            NextAvailableNumber = 20000000;
        }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextClientNumberId { get; set; }

        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Returns an instance of NextClientNumber
        /// </summary>
        /// <returns>nextClientNumber</returns>
        public static NextClientNumber GetInstance()
        {
            BankOfBITContext db = new BankOfBITContext();

            if (nextClientNumber == null)
            {
                nextClientNumber = db.NextClientNumbers.SingleOrDefault();

                if (nextClientNumber == null)
                {
                    nextClientNumber = new NextClientNumber();
                    db.NextClientNumbers.Add(nextClientNumber);
                    db.SaveChanges();
                }
            }

            return nextClientNumber;
        }
    }

#endregion

#region Payee

    /// <summary>
    /// Payee class - represents the Payee table in the database
    /// </summary>
    public class Payee
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PayeeId { get; set; }

        [Display(Name="Payee")]
        public string Description { get; set; }
    }

#endregion

#region Institution

    /// <summary>
    /// Institution Class - represents the Institution table in the database
    /// </summary>
    public class Institution
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InstitutionId { get; set; }

        [Display(Name="Institution\nNumber")]
        public int InstituionNumber { get; set; }

        [Display(Name="Institution")]
        public string Description { get; set; }
    }

#endregion

#region StoredProcedures

    /// <summary>
    /// Stored Procedure model for the Bank of BIT 
    /// </summary>
    public static class StoredProcedures
    {
        /// <summary>
        /// Returns the next Id number in the database table
        /// </summary>
        /// <param name="tableName">The name of the table the SQL is being run against</param>
        /// <returns>returnValue</returns>
        public static long? NextNumber(string tableName)
        {
            // Creates an SQL Server connection object
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=BankOfBITContext;Integrated Security=True");

            // Assigns an initial value of 0 to a nullable long
            long? returnValue = 0;

            try
            {
                // Creates an SQL command object to be run against the database
                SqlCommand storedProcedure = new SqlCommand("next_number", connection);

                // Indicates how the CommandText property is to be interpreted
                storedProcedure.CommandType = System.Data.CommandType.StoredProcedure;

                // The parameters being passed to Command object
                storedProcedure.Parameters.AddWithValue("@TableName", tableName);

                // Creates a parameter object (output)
                SqlParameter outputParameter = new SqlParameter("@NewVal", SqlDbType.BigInt)
                {
                    // Indicates that the value is output-only
                    Direction = ParameterDirection.Output
                };

                // Adds the outputParameter to the Parameters property of the SQL command
                storedProcedure.Parameters.Add(outputParameter);

                // Opens the connection to the database
                connection.Open();

                // Executes a T-SQL statement against the connection and returns the number of rows affected
                storedProcedure.ExecuteNonQuery();

                // Close connection to the database
                connection.Close();

                returnValue = (long?)outputParameter.Value;
            }
            catch (Exception)
            {
                // Assigns a null value to returnValue should an exception occur
                returnValue = null;
            }

            return returnValue;
        }
    }

#endregion
}