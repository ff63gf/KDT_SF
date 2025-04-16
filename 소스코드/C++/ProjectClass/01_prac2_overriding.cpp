#include <iostream>

class Shape 
{
	protected:
		int lineCount;
		int lengthOfBase;

	public:
		Shape() {}

		void printInfo() 
		{
			std::cout << "���� ����:" << lineCount << ", �غ��� ���� : " << lengthOfBase;
		}
};

class Rectangle : public Shape 
{
	int verticalLength;

	public : 
		Rectangle(int count, int base, int vertical) 
		{
			lineCount = count;
			lengthOfBase = base;
			verticalLength = vertical;
;		}

		int area() 
		{
			return lengthOfBase * verticalLength;
		}

		void printInfo() 
		{
			std::cout << "�簢���� ���̴� " << area() << std::endl;
		}
};

class Triangle : public Shape 
{
	int height;

	public:
		Triangle(int count, int base, int h) 
		{
			lineCount = count;
			lengthOfBase = base;
			height = h;
			;
		}

		int area() 
		{
			return lengthOfBase * height;
		}

		void printInfo() 
		{
			std::cout << "�ﰢ���� ���̴� " << area() << std::endl;
		}
};

int main() 
{
	Rectangle r = Rectangle(4, 3, 2);
	Triangle t = Triangle(3, 2, 1);

	r.printInfo();
	t.printInfo();

	return 0;
}