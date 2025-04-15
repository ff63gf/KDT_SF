using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppVendingMachine
{
    internal class VendingMachine
    {
        // 음료 가격은 500원
        int total_money = 0;
        int input_money = 0;
        int drink_count = 10;
        string password = "1234";
        bool is_manager = false;

        public void GetCost(int money)
        {
            this.input_money += money;
        }

        public int VendAndChange()
        {
            if (this.input_money > 500)
            {
                int change = this.input_money - 500;
                this.total_money += 500;
                this.drink_count--;
                return change;
            }
            else
            {
                return 0;
            }
        }

        public void ManageMode(string password)
        {
            if (this.password == password)
            {
                this.is_manager = true;
            }
            else
            {
                this.is_manager = false;
            }
        }

        public void AddDrink(int count)
        {
            this.drink_count += count;
        }


    }
}
