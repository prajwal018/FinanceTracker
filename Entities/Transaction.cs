namespace Entities
{
    public class Transaction
    {
        public double amount { get; set; }
        public string category { get; set; }
        public string description { get; set; }

        public Transaction(double amount, string category, string description)
        {
            this.amount = amount;
            this.category = category;
            this.description = description;
        }

        public override string? ToString()
        {
            return "Transaction{" + "amount=" + amount + ", category='" + category + '\''
                + ", description='" + description + '\'' + "}\n";

        }
    }
}
