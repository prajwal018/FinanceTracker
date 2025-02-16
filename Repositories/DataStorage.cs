using Entities;

namespace Repositories
{
    public class DataStorage
    {
        public List<Transaction> transactions { get; }
        public Dictionary<string, Budget> budgets { get; }
        private string budgetFileName = "budgets.txt";
        private string transactionsFileName = "transactions.txt";

        public DataStorage()
        {
            this.transactions = new List<Transaction>();
            this.budgets = new Dictionary<string, Budget>();
            LoadTransactions();
            LoadBudgets();
        }

        private void LoadBudgets()
        {
            try
            {
                using (StreamReader reader = new StreamReader(new FileInfo($"./{budgetFileName}").FullName))
                {
                    String line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        String[] parts = line.Split(",");
                        if (parts.Length == 3)
                        { // Ensure correct format
                            try
                            {
                                String category = parts[0];
                                double limit = double.Parse(parts[1]);
                                double spent = double.Parse(parts[2]);
                                Budget budget = new Budget(category, limit);
                                budget.AddSpending(spent);
                                budgets.Add(category, budget); //map input
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Skipping invalid transaction entry: " + line);
                            }
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error loading transactions: " + e.Message);
            }
        }

        private void LoadTransactions()
        {
            try
            {
                using (StreamReader reader = new StreamReader(new FileInfo($"./{transactionsFileName}").FullName))
                {
                    String line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        String[] parts = line.Split(",");
                        if (parts.Length == 3)
                        { // Ensure correct format
                            try
                            {
                                double amount = double.Parse(parts[0]);
                                String category = parts[1];
                                String description = parts[2];
                                transactions.Add(new Transaction(amount, category, description));
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Skipping invalid transaction entry: " + line);
                            }
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error loading transactions: " + e.Message);
            }
        }

        public void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
            SaveTransactions();
        }

        public void setBudget(string category, Budget budget)
        {
            budgets[category]=budget;
            SaveBudgets();
        }

        private void SaveTransactions()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(transactionsFileName))
                {
                    foreach (Transaction transaction in transactions)
                    {
                        writer.WriteLine(transaction.amount + "," + transaction.category + ","
                                + transaction.description);
                        //writer.newLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error saving transactions: " + e.Message);
            }

        }

        private void SaveBudgets()
        {
            try{
                using (StreamWriter writer = new StreamWriter(budgetFileName)) { 
                    foreach(Budget budget in budgets.Values)
                    {
                        writer.WriteLine(budget.category + "," + budget.limit + "," + budget.spent);
                        //writer.newLine();
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine("Error saving transactions: " + e.Message);
            }
        }




    }
}
