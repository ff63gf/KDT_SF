using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppVendingMachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            User user = new User();
            VendingMachine machine = new VendingMachine();
            VendingMachineManager manager = new VendingMachineManager();

            // 사용자가 1000원을 지불하고 자판기에게서 음료 받기
            machine.GetCost(user.Pay(1000));
            user.GetDrinkAndChange(machine.VendAndChange());

            // 관리자 모드로 들어가서 음료 추가 후 관리자 모드 끄기
            machine.ManageMode(manager.GetPassword());
            machine.AddDrink(manager.Fill(10));
            machine.ManageMode("x");
        }
    }
}
