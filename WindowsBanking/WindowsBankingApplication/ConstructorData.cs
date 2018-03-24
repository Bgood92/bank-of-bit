using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankOfBIT.Models;

namespace WindowsBankingApplication
{
    /// <summary>
    /// given:TO BE MODIFIED
    /// this class is used to capture data to be passed
    /// among the windows forms
    /// </summary>
    public class ConstructorData
    {
        /*
         * The following autoimplemented properties are used to pass Client-specific and 
         * BankAccount-specific data among the forms in the WindowsBankingApplication project
         */
        public Client Client { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
