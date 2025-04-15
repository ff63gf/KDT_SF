using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppVendingMachine
{
    internal class VendingMachineManager
    {
        string password = "1234";
        int drink_count = 100;

        public int Fill(int count)
        {
            this.drink_count -= count;
            if (drink_count <= 0)
            {
                this.drink_count = 0;
                return 0;
            }

            return this.drink_count;
        }

        public string GetPassword()
        {
            return password;
        }
    }
}
