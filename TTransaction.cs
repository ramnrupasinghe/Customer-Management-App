using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementApp
{
    public enum TransactionType
    {
        Sale,
        Purchase,
        Expense,
        Income
    }

    public class TTransaction
    {
        public decimal Transactionn { get; set; }
        public string Descriptionn { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType Type { get; set; }
        public List<string> Tags { get; set; }

        public TTransaction(decimal amount, string description, DateTime transactionDate, TransactionType type, List<string> tags)
        {
            Transactionn = amount;
            Descriptionn = description;
            TransactionDate = transactionDate;
            Type = type;
            Tags = tags;
        }
    }
}
