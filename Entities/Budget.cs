using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Budget
    {
        public string category { get; set; }
        public double limit { get; set; }
        public double spent { get; set; }

        public Budget(string category, double limit)
        {
            this.category = category;
            this.limit = limit;
            this.spent = 0;
        }

        public void AddSpending(double amount)
        {
            this.spent += amount;
        }

        public bool IsOverBudget()
        {
            return spent > limit;
        }

        public override string? ToString()
        {
            return "Budget{" +
                "category='" + category + '\'' +
                ", limit=" + limit +
                ", spent=" + spent +
                "}\n";
        }
    }
}
