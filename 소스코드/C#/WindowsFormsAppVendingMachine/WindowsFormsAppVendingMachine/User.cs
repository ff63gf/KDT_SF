using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppVendingMachine
{
    internal class User
    {
        int money = 10000;
        int drink_count = 0;

        public int Pay(int cost)
        {
            this.money -= cost;
            if (this.money < 0)
            {
                this.money = 0;
                return -1; // error
            }
            return cost;
        }

        public void GetDrinkAndChange(int money)
        {
            this.money += money;
            this.drink_count++;
        }
    }
}
