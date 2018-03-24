using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    /// <summary>
    /// A helper class to assist in design functions of the project
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Grabs the first part of a long string and returns it
        /// </summary>
        /// <param name="s">The string object that is to be eliminated</param>
        /// <param name="o">The instance object being evaluated</param>
        /// <returns>The first word in the object string</returns>
        public static string GetDescription(string s, object o)
        {
            string accountType = o.GetType().Name;
            return accountType.Substring(0, accountType.IndexOf(s));
        }
    }
}
