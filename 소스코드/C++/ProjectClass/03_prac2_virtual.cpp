//
// 240516, john
// 클래스 심화2 PPT, 실습2 가상함수
// 

// override 키워드
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
		cout << "사람입니다~" << endl;
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

	// 상속 받는 입장에서 virtual 키워드는 생략 가능하나 써주는 것이 예의
	void intro() override
	{
		cout << name << "학생입니다." << endl;
	}

	void learn()
	{
		cout << "배웁니다." << endl;
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
		cout << name << "선생입니다." << endl;
	}

	void teach()
	{
		cout << "가르칩니다." << endl;
	}
};


int main()
{
	Person* pList[3];
	string names[3];

	cout << "3명의 이름을 입력해주세요.(선생님, 학생, 학생)" << endl;
	cin >> names[0] >> names[1] >> names[2];

	/* names[] 배열 이용하여 각 class 생성 */
	Teacher* teacher = new Teacher(names[0]);
	Student* student1 = new Student(names[1]);
	Student* student2 = new Student(names[2]);

	/* pList에 할당하는 코드 추가 */
	// 동적 바인딩, 주소값 = 포인터(*), 레퍼런스(&)
	pList[0] = teacher; // teacher 인스턴스의 주소값 복사
						// teacher 인스턴스의 내용 (X)
	pList[1] = student1;
	pList[2] = student2;

	// overriding : virtual 을 사용하지 않으면, 부모 메소드가 작동한다
	// 이유? -> 동적 바인딩 : 런 타임에서 실제 주소값에 해당하는 인스턴스를 확인
	// static_cast, dynamic_cast

	for (auto p : pList)
	{				// < 동적 바인딩 > - 실행 중에 = 런 타임
		p->intro(); // 주소값을 찾아가서 pList 인스턴스의 내용 (O)
	}

	/* 각 class의 고유 함수 실행 (teach(), learn(), learn()) */
	((Teacher*)pList[0])->teach();
	((Student*)pList[1])->learn();
	((Student*)pList[2])->learn();

	return 0;
}