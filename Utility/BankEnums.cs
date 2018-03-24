using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public enum TransactionTypeValues
    {
        Deposit = 1,
        Withdrawal,
        BillPayment,
        Transfer,
        TransferRecipient,
        CalculateInterest
    };
}
