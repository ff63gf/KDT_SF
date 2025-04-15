using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsAppDerived
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Square square = new Square();
            //Shape shape = new Shape();

            //Test();

            //Child child1 = new Child();
            //Child child2 = new Child("John");
            Child child3 = new Child("John", 123);
        }

        void Test()
        {
            Child child = new Child();

            // 자식 -> 부모, 업캐스팅
            Weapon weapon = new Sword(200);

            // 부모의 메소드는 평범하게 이용 가능
            int attack = weapon.Attack();

            // 자식의 메소드는 자식 클래스로 캐스팅하여 사용
            int skill_attack = ((Sword)weapon).Slash(1);

            // 인스턴스를 덮어 쓰는 것으로 자식 클래스를 변경 가능
            weapon = new Gun(100);
            attack = weapon.Attack();
            skill_attack = (((Gun)weapon).Fire(10));
        }

    }
}
