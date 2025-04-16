#include <iostream>
#include <vector>

using std::string;
using std::cout;
using std::cin;
using std::endl;

// Candy : Snack
// Candy c; -> {Candy(), Snack()} , {Chocolate(), Snack()}
// Snack Vector <- push (new Candy or new Chocolate)
// Snack Vector <- pop, delete(remove)
// Up-Casting


//   Snack(Vec)      <-Up-Casting-         Snack 
//   pop,delete							(new Candy) - �Ҹ��� �۵�(X)
//


class Snack 
{
protected:
	int price;
	string name;
	string maker;
	static int count;
public:
	Snack(){ count++; } // 1
	virtual ~Snack() { count--; } // 2
	static int get_count() 
	{
		return count;
	}
	string get_name() 
	{
		return name;
	}
	virtual void show_info() 
	{
		cout << "�����Դϴ�~" << endl;
	}
};

int Snack::count = 0;

class Candy : public Snack 
{
	string flavor;
public:
	Candy(string flavor) 
	{
		this->price = 200;
		this->name = "����";
		this->maker = "���";
		this->flavor = flavor;
	}
	void show_info() override
	{
		cout << flavor << "�� ����" << endl;
	}
};

class Chocolate : public Snack 
{
	string shape;
public:
	Chocolate(string shape) 
	{
		this->price = 1000;
		this->name = "���ݸ�";
		this->maker = "�Ե�";
		this->shape = shape;
	}

	void show_info() override
	{
		cout << shape << "��� ���ݸ�" << endl;
	}
};


int main() 
{
	std::vector<Snack*> snack_basket;

	while (1) 
	{
		int product;
		cout << "���� �ٱ��Ͽ� �߰��� ������ ���ÿ�.( 1: ����, 2: ���ݸ�, 0: ���� ) : ";
		cin >> product;
		if (product == 0) break; 
		else if (product == 1) 
		{
			string taste;
			cout << "���� �Է��ϼ���. : ";
			cin >> taste;
			snack_basket.push_back(new Candy(taste)); // 4
		} 
		else if (product == 2) 
		{
			string shape;
			cout << "����� �Է��ϼ���. : ";
			cin >> shape;
			snack_basket.push_back(new Chocolate(shape)); // 4
		} 
		else 
		{
			cout << "0~2 ������ ���ڸ� �Է��ϼ���. \n";
		}

		cout << endl;
	}

	cout << endl;

	//delete snack_basket.back();
	//snack_basket.pop_back();

	cout << "���� �ٱ��Ͽ� ��� ������ ������ " << Snack::get_count() << "�� �Դϴ�.\n";

	cout << "\n���� �ٱ��Ͽ� ��� ���� Ȯ���ϱ�!\n";

	for (Snack* snack : snack_basket) 
	{
		snack->show_info(); // 3
	}

	return 0;
}