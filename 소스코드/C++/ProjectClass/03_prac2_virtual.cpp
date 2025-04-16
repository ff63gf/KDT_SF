//
// 240516, john
// Ŭ���� ��ȭ2 PPT, �ǽ�2 �����Լ�
// 

// override Ű����
// https://blockdmask.tistory.com/415


#include <iostream>
#include <string>

using std::cout;
using std::cin;
using std::endl;
using std::string;


class Person
{
public:
	virtual void intro()
	{
		cout << "����Դϴ�~" << endl;
	}
};

class Student : public Person
{
	string name;

public:
	Student(string name)
	{
		this->name = name;
	}

	// ��� �޴� ���忡�� virtual Ű����� ���� �����ϳ� ���ִ� ���� ����
	void intro() override
	{
		cout << name << "�л��Դϴ�." << endl;
	}

	void learn()
	{
		cout << "���ϴ�." << endl;
	}
};


class Teacher : public Person
{
	string name;

public:
	Teacher(string name)
	{
		this->name = name;
	}

	void intro() override
	{
		cout << name << "�����Դϴ�." << endl;
	}

	void teach()
	{
		cout << "����Ĩ�ϴ�." << endl;
	}
};


int main()
{
	Person* pList[3];
	string names[3];

	cout << "3���� �̸��� �Է����ּ���.(������, �л�, �л�)" << endl;
	cin >> names[0] >> names[1] >> names[2];

	/* names[] �迭 �̿��Ͽ� �� class ���� */
	Teacher* teacher = new Teacher(names[0]);
	Student* student1 = new Student(names[1]);
	Student* student2 = new Student(names[2]);

	/* pList�� �Ҵ��ϴ� �ڵ� �߰� */
	// ���� ���ε�, �ּҰ� = ������(*), ���۷���(&)
	pList[0] = teacher; // teacher �ν��Ͻ��� �ּҰ� ����
						// teacher �ν��Ͻ��� ���� (X)
	pList[1] = student1;
	pList[2] = student2;

	// overriding : virtual �� ������� ������, �θ� �޼ҵ尡 �۵��Ѵ�
	// ����? -> ���� ���ε� : �� Ÿ�ӿ��� ���� �ּҰ��� �ش��ϴ� �ν��Ͻ��� Ȯ��
	// static_cast, dynamic_cast

	for (auto p : pList)
	{				// < ���� ���ε� > - ���� �߿� = �� Ÿ��
		p->intro(); // �ּҰ��� ã�ư��� pList �ν��Ͻ��� ���� (O)
	}

	/* �� class�� ���� �Լ� ���� (teach(), learn(), learn()) */
	((Teacher*)pList[0])->teach();
	((Student*)pList[1])->learn();
	((Student*)pList[2])->learn();

	return 0;
}