using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppStatic
{
    public class Dog
    {
        private static int num;
        public static int Count
        {
            get { return num; }
        }
        public static int getNumber()
        {
            return num;
        }

        public Dog() { num++; }

        ~Dog() { num--; }
    }
}
