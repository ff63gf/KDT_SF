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
//   pop,delete							(new Candy) - 소멸자 작동(X)
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
		cout << "과자입니다~" << endl;
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
		this->name = "사탕";
		this->maker = "농심";
		this->flavor = flavor;
	}
	void show_info() override
	{
		cout << flavor << "맛 사탕" << endl;
	}
};

class Chocolate : public Snack 
{
	string shape;
public:
	Chocolate(string shape) 
	{
		this->price = 1000;
		this->name = "초콜릿";
		this->maker = "롯데";
		this->shape = shape;
	}

	void show_info() override
	{
		cout << shape << "모양 초콜릿" << endl;
	}
};


int main() 
{
	std::vector<Snack*> snack_basket;

	while (1) 
	{
		int product;
		cout << "과자 바구니에 추가할 간식을 고르시오.( 1: 사탕, 2: 초콜릿, 0: 종료 ) : ";
		cin >> product;
		if (product == 0) break; 
		else if (product == 1) 
		{
			string taste;
			cout << "맛을 입력하세요. : ";
			cin >> taste;
			snack_basket.push_back(new Candy(taste)); // 4
		} 
		else if (product == 2) 
		{
			string shape;
			cout << "모양을 입력하세요. : ";
			cin >> shape;
			snack_basket.push_back(new Chocolate(shape)); // 4
		} 
		else 
		{
			cout << "0~2 사이의 숫자를 입력하세요. \n";
		}

		cout << endl;
	}

	cout << endl;

	//delete snack_basket.back();
	//snack_basket.pop_back();

	cout << "과자 바구니에 담긴 간식의 개수는 " << Snack::get_count() << "개 입니다.\n";

	cout << "\n과자 바구니에 담긴 간식 확인하기!\n";

	for (Snack* snack : snack_basket) 
	{
		snack->show_info(); // 3
	}

	return 0;
}