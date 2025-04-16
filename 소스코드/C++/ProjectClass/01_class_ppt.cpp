#include <iostream>

using std::cout;
using std::endl;
using std::string;

class Person {
protected: // 부모클래스에서는 private 대신 protected를 자주 사용함.
	string name;
	int age;
public:
	Person() {}
	Person(string name) { this->name = name; }
	void talk() { cout << "말하기" << endl; }
	void eat() { cout << "먹기" << endl; }
	void sleep() { cout << "잠자기" << endl; }
};

class Student : public Person { // 여기서 public 은 Person으로 부터 상속 받은 멤버들의 접근제어자 한계를 지정함. public을 쓰는 게 일반적
	string stu_id;
public:
	Student(string name, string stu_id) : Person(name) { // 매개변수가 1개인 Person 생성자 호출, 써주지 않는다면 Person() 호출
		this->stu_id = stu_id;
	}
	void study() { cout << "공부하기" << endl; }
	void sleep() { cout << "잠자기 오버라이딩" << endl; } // 오버라이딩
	void sleep(int hour) { cout << hour << "시간 만큼 잠자기" << endl; } // 오버로딩
	void test() {
		//this->name = "aaaa";
		cout << name << endl;
		talk();
	}
};


//class Student : protected Person { // protected로 지정하면 Person의 public 접근은 모두 protected로 바뀜. private은 그대로
//public:
//	void study() { cout << "공부하기" << endl; }
//	void action() {
//		talk();
//		eat();
//		sleep();
//	}
//protected:
//	string name;
//	int age;
//	void talk() { cout << "말하기" << endl; }
//	void eat() { cout << "먹기" << endl; }
//	void sleep() { cout << "잠자기" << endl; }
//};

int main() {
	Student stu("홍길동", "11111111");
	stu.sleep();
	stu.test();

	// stu.age = 5;

	return 0;
}