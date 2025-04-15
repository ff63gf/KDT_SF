using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWPFApp
{
    internal class SingletonTest
    {
        // static 영역에 객체 생성
        static SingletonTest staticSingleton;

        public static SingletonTest Instance()
        {
            // 객체에 아직 할당된 인스턴스가 없다면 인스턴스화
            if(staticSingleton == null)
            {
                staticSingleton = new SingletonTest();
            }
            // 객체에 할당된 인스턴스가 있다면, 그냥 인스턴스를 리턴
            return staticSingleton;
        }
    }

    class Test
    {
        public Test()
        {
            // new 키워드를 사용하여 인스턴스 생성을 하지 않음
            //SingletonTest singleton = new SingletonTest();

            // 여러번 인스턴스를 생성하려 해도 최초 1회만 생성, 이후는 참조됨
            SingletonTest singleton1 = SingletonTest.Instance();
            SingletonTest singleton2 = SingletonTest.Instance();
        }
    }
}
