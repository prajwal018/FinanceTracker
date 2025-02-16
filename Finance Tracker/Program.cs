
using Repositories;

namespace FinanceTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FinanceService financeService = new FinanceService(new DataStorage());
            try
            {
                while (true)
                {
                    Console.WriteLine("1. Add Transaction");
                    Console.WriteLine("2. View Transactions");
                    Console.WriteLine("3. Set Budget");
                    Console.WriteLine("4. View Budgets");
                    Console.WriteLine("5. Check Budgets");
                    Console.WriteLine("6. Exit");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter amount: ");
                            double amount = double.Parse(Console.ReadLine());
                            //sc.nextLine();
                            Console.WriteLine("Enter Category: ");
                            string? category = Console.ReadLine();
                            Console.WriteLine("Enter description: ");
                            string? description = Console.ReadLine();
                            financeService.AddTransaction(new Entities.Transaction(amount, category, description));
                            break;
                        case 2:
                            financeService.viewTransactions();
                            break;
                        case 3:
                            Console.WriteLine("Enter category:");
                            string? budgetCategory = Console.ReadLine();
                            Console.WriteLine("Enter limit:");
                            double limit = double.Parse(Console.ReadLine());
                            financeService.setBudget(budgetCategory, limit);
                            break;
                        case 4:
                            financeService.viewBudgets();
                            break;
                        case 5:
                            financeService.checkBudgets();
                            break;
                        case 6:
                            return;
                        default:
                            Console.WriteLine("Invalid Choice.");
                            break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exited");
            }
        }

    }
}
