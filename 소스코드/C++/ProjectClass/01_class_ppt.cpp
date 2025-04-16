#include <iostream>

using std::cout;
using std::endl;
using std::string;

class Person {
protected: // �θ�Ŭ���������� private ��� protected�� ���� �����.
	string name;
	int age;
public:
	Person() {}
	Person(string name) { this->name = name; }
	void talk() { cout << "���ϱ�" << endl; }
	void eat() { cout << "�Ա�" << endl; }
	void sleep() { cout << "���ڱ�" << endl; }
};

class Student : public Person { // ���⼭ public �� Person���� ���� ��� ���� ������� ���������� �Ѱ踦 ������. public�� ���� �� �Ϲ���
	string stu_id;
public:
	Student(string name, string stu_id) : Person(name) { // �Ű������� 1���� Person ������ ȣ��, ������ �ʴ´ٸ� Person() ȣ��
		this->stu_id = stu_id;
	}
	void study() { cout << "�����ϱ�" << endl; }
	void sleep() { cout << "���ڱ� �������̵�" << endl; } // �������̵�
	void sleep(int hour) { cout << hour << "�ð� ��ŭ ���ڱ�" << endl; } // �����ε�
	void test() {
		//this->name = "aaaa";
		cout << name << endl;
		talk();
	}
};


//class Student : protected Person { // protected�� �����ϸ� Person�� public ������ ��� protected�� �ٲ�. private�� �״��
//public:
//	void study() { cout << "�����ϱ�" << endl; }
//	void action() {
//		talk();
//		eat();
//		sleep();
//	}
//protected:
//	string name;
//	int age;
//	void talk() { cout << "���ϱ�" << endl; }
//	void eat() { cout << "�Ա�" << endl; }
//	void sleep() { cout << "���ڱ�" << endl; }
//};

int main() {
	Student stu("ȫ�浿", "11111111");
	stu.sleep();
	stu.test();

	// stu.age = 5;

	return 0;
}