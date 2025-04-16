//
// 240516, john
// Ŭ���� ��ȭ2 PPT, �ǽ�1 ��/�ٿ�ĳ����
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
	// ��ĳ����, �ڳ� Ŭ���� ���� �޼ҵ�, �ʵ� ���� ��� �Ұ�
	// �ڳ�Ŭ���� ���� �ִ�, �����Ͱ� ��������� ����
	Snack* snackBasket[4] = { new Candy("chupachups", "perfetti"),
							  new Candy("rollipop", "wendy"),
							  new Chocolate("gana", "lotte"),
							  new Chocolate("ferrero", "ferrero")};


	for (Snack* snack : snackBasket)
	{
		// ��ĳ���� �Ǿ��⿡, chocolate, candy�� �����ִ� �޼ҵ�� ��� �Ұ�
		snack->printProdName();
	}

	cout << endl;


	// ��ĳ���� �� ���� �ٽ� �ٿ�ĳ�����Ͽ� �ڽ� Ŭ���� ���� �޼ҵ� ���
	// �ڳ�Ŭ���� ���� �ִ�, �����Ͱ� ������
	((Candy*)snackBasket[0])->printManufac();
	((Candy*)snackBasket[1])->printManufac();
	((Chocolate*)snackBasket[2])->printManufac();
	((Chocolate*)snackBasket[3])->printManufac();

	cout << endl; 

	//fdasfdsa

	return 0;
}