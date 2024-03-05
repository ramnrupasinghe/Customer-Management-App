using System;

public class Transaction
{
    public DateTime Date { get; set; }
    public decimal TransactionAmount { get; set; }
    public string Description { get; set; }
    public string TransactionCategory { get; set; }
    public string TransactionCurrency { get; set; }

    public Transaction(DateTime date, decimal amount, string description, string category, string currency)
    {
        Date = date;
        TransactionAmount = amount;
        Description = description;
        TransactionCategory = category;
        TransactionCurrency = currency;
    }
}