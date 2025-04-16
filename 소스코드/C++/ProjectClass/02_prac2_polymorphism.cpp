//
// 240516, john
// Ŭ���� ��ȭ PPT, �ǽ�2 ������
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
	void printProdName() { std::cout << prod_name << endl; }
};


class Candy : public Snack
{
	string taste;

public:
	Candy(string name)
	{
		this->prod_name = name;
	}
};


class Chocolate : public Snack
{
	string shape;

public:
	Chocolate(string name)
	{
		this->prod_name = name;
	}
};


int main()
{
	Candy candy1("chupachups");
	Candy candy2("rollipop");
	Chocolate choco1("gana");
	Chocolate choco2("ferrero");

	Snack snackBasket[4];
	snackBasket[0] = candy1;
	snackBasket[1] = candy2;
	snackBasket[2] = choco1;
	snackBasket[3] = choco2;



	for (auto snack : snackBasket)
	{
		snack.printProdName();
	}

	cout << endl;

	return 0;
}
