using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDerived
{
    // 부모 클래스
    public class Shape
    {
        protected string getShape() => "Shape";
        public string getShape2() => "Shape2";
        private string getShape3() => "Shape3";
        internal string getShape4() => "Shape4";

        protected int a;
        public int b;

        public int c { get; set; }
        private int d;
    }

    // 자식 클래스
    public class Square : Shape
    {
        // getShape(): 부모 클래스의 것
        public Square() => MessageBox.Show(getShape());

        void test()
        {
            // 부모 클래스의 변수
            a = 1;
            b = 2;
            c = 3;
        }
    }


    #region 상속
    public class Parent
    {
        string name;
        int id;

        public Parent() // 기본 생성자
        { 
            MessageBox.Show("Parent Default"); 
        }
        public Parent(string name) 
        { 
            this.name = name;
            MessageBox.Show("Parent: " + name);
        }
        public Parent(string name, int id) 
        {
            this.name = name;
            this.id = id;
            MessageBox.Show("Parent: " + name + id.ToString());
        }
    }

    public class Child : Parent
    {
        public Child()
        {
            MessageBox.Show("Child Default");
        }
        public Child(string name)
        {
            MessageBox.Show("Child: " + name);
        }
        public Child(string name, int id) : base(name)
        {
            MessageBox.Show("Child: " + name + id.ToString());
        }
    }
    #endregion

    #region 인터페이스
    //public interface IHuman
    //{
    //    // 인터페이스는 기능 구현을 하지 않음
    //    void Talk();
    //}

    //public interface IParent 
    //{
    //    void GetChild();
    //}

    //// 인터페이스는 다중 상속이 가능
    //public class Child : IHuman, IParent
    //{
    //    // 인터페이스의 메소드를 반드시 오버라이딩 해야함
    //    public void Talk() { }
    //    public void GetChild() { }
    //}
    #endregion

    #region 업캐스팅
    public class Weapon
    {
        protected int damage;

        public Weapon(int damage) 
        { this.damage = damage; }

        public int Attack() => damage;
    }

    public class Sword : Weapon
    {
        int attack_range = 1;

        // base()를 통해 부모 생성자에게 전달됨
        public Sword(int damage) : base(damage) {}

        public int Slash(int range)
        {
            if (this.attack_range >= range)
            {
                return this.damage;
            }
            return 0;
        }
    }

    public class Gun : Weapon
    {
        int attack_range = 10;

        public Gun(int damage) : base(damage) { }

        public int Fire(int range)
        {
            if(this.attack_range >= range)
            {
                return this.damage; 
            }
            return 0;
        }
    }
    #endregion

}




