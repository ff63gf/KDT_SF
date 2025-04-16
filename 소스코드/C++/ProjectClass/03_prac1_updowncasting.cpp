//
// 240516, john
// 클래스 심화2 PPT, 실습1 업/다운캐스팅
// 


#include <iostream>
#include <string>

using std::cout;
using std::string;
using std::endl;


class Snack
{
protected:
	int price;
	string prod_name;
	string manufac_name;

public:
	virtual void printProdName() { cout << prod_name << endl; }
};


class Candy : public Snack
{
	string taste;

public:
	Candy(string name, string manufac)
	{
		this->prod_name = name;
		this->manufac_name = manufac;
	}

	void printProdName() override final { cout << prod_name << endl; }

	void printManufac() { cout << manufac_name << endl; }
};

class B : public Candy
{
	void printProdName()
	{

	}
};


class Chocolate : public Snack
{
	string shape;

public:
	Chocolate(string name, string manufac)
	{
		this->prod_name = name;
		this->manufac_name = manufac;
	}

	void printManufac() { cout << manufac_name << endl; }
};


//https://helloworld-japan.tistory.com/33
int main()
{
	// stack
	//Candy candy1("chupachups", "perfetti");
	//Candy candy2("rollipop", "wendy");
	//Chocolate choco1("gana", "lotte");
	//Chocolate choco2("ferrero", "ferrero");

	//Snack* snackBasket[4];
	//snackBasket[0] = &candy1;
	//snackBasket[1] = &candy2;
	//snackBasket[2] = &choco1;
	//snackBasket[3] = &choco2;

	// heap
	// 업캐스팅, 자녀 클래스 고유 메소드, 필드 변수 사용 불가
	// 자녀클래스 갖고 있는, 데이터가 사라지지는 않음
	Snack* snackBasket[4] = { new Candy("chupachups", "perfetti"),
							  new Candy("rollipop", "wendy"),
							  new Chocolate("gana", "lotte"),
							  new Chocolate("ferrero", "ferrero")};


	for (Snack* snack : snackBasket)
	{
		// 업캐스팅 되었기에, chocolate, candy만 갖고있는 메소드는 사용 불가
		snack->printProdName();
	}

	cout << endl;


	// 업캐스팅 된 것을 다시 다운캐스팅하여 자식 클래스 전용 메소드 사용
	// 자녀클래스 갖고 있는, 데이터가 복구됨
	((Candy*)snackBasket[0])->printManufac();
	((Candy*)snackBasket[1])->printManufac();
	((Chocolate*)snackBasket[2])->printManufac();
	((Chocolate*)snackBasket[3])->printManufac();

	cout << endl; 

	//fdasfdsa

	return 0;
}