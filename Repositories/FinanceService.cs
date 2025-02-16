using Entities;

namespace Repositories
{
    public class FinanceService
    {
        private DataStorage dataStorage { get; set; }

        public FinanceService(DataStorage dataStorage)
        {
            this.dataStorage = dataStorage;
        }

        public void AddTransaction(Transaction transaction)
        {
            try
            {
                dataStorage.AddTransaction(transaction);
                if (dataStorage.budgets.ContainsKey(transaction.category))
                {
                    Budget budget = dataStorage.budgets[transaction.category];
                    budget.AddSpending(transaction.amount);
                    dataStorage.setBudget(transaction.category, budget);
                }
                Console.WriteLine("Transaction added successfully: " + transaction);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding transaction: " + e.Message);
            }
        }

        public void viewTransactions()
        {
            try
            {
                List<Transaction> transactions = dataStorage.transactions;
                foreach (Transaction transaction in transactions)
                {
                    Console.WriteLine(transaction); // Consider using a formatted output or log it
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving transactions: " + e.Message);
            }
        }

        public void setBudget(String category, double limit)
        {
            Budget budget = new Budget(category, limit);
            dataStorage.setBudget(category, budget);
        }

        public void viewBudgets()
        {
            Dictionary<string, Budget> budgets = dataStorage.budgets;
            foreach (Budget budget in budgets.Values)
            {
                Console.WriteLine(budget);
            }
        }

        public void checkBudgets()
        {
            Dictionary<string, Budget> budgets = dataStorage.budgets;
            foreach (Budget budget in budgets.Values)
            {
                if (budget.IsOverBudget())
                {
                    Console.WriteLine("Over Budget: You are over limit by " + (budget.spent - budget.limit) + " in " + budget.category);

                }
                else
                {
                    Console.WriteLine("Under Budget: You can still spend " + (budget.limit - budget.spent) + " in " + budget.category);
                }
            }
        }
    }
}
