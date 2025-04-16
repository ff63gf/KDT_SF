using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppClass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    class Dog
    {
        public static string voice = "먼먼";
        public static string Vox() => voice;

        public void test()
        {
            voice = "가나다";
            Vox();
        }
    }

   public class Weapon
    {
        public int power;
        public int speed;

        //public Weapon()
        //{
        //    power = 10;
        //    speed = 2;
        //}

        //public Weapon(int power, int speed)
        //{
        //    this.power = power;
        //    this.speed = speed;
        //}

        public void getInfo()
        {
            Console.Write($"power {power}, speed {speed}");
        }
    }

    public class Rifle:Weapon
    {
        public int bullet;

        public Rifle()
        {
            bullet = 30;
        }

        public int combatPoint()
        {
            return power * speed * bullet;
        }

        public void getInfo()
        {
            Console.Write($"power {power}, speed {speed}, bullet {bullet}");
        }
        public void setCombatPoint(int power)
        {
            this.power = power;
        }
        public void setCombatPoint(int power, int speed)
        {
            this.power = power;
            this.speed = speed;
        }
        public void setCombatPoint(int power, int speed, int bullet)
        {
            this.power = power;
            this.speed = speed;
            this.bullet = bullet;
        }
    }

    public class Knife:Weapon
    {
        public int sharpness;

        public Knife()
        {
            sharpness = 8;
        }
        public int combatPoint()
        {
            return power * speed * sharpness;
        }

        public void getInfo()
        {
            Console.Write($"power {power}, speed {speed}, sharpness {sharpness}");
        }

        public void setCombatPoint(int power)
        {
            this.power = power;
        }
        public void setCombatPoint(int power, int speed)
        {
            setCombatPoint(power);
            this.speed = speed;
        }
        public void setCombatPoint(int power, int speed, int sharpness)
        {
            setCombatPoint(power, speed);
            this.sharpness = sharpness;
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Weapon weapon = new Weapon();
            //Weapon weapon2 = new Weapon(1, 2);

            Rifle rifle = new Rifle();
            Knife knife = new Knife();

            int rc = rifle.combatPoint();
            knife.combatPoint();

            Dog dog = new Dog();
            Dog dog2 = new Dog();

            // 인스턴스 개수는 총 {Dog.num} 개입니다.



            Dog.voice = "멍뭉";
            Dog.Vox();
        }
    }
}