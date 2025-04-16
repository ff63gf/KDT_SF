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
			std::cout << "변의 개수:" << this->lineCount << ", 밑변의 길이 : " << this->lengthOfBase;
		}
};

class Rectangle : public Shape 
{
	int verticalLength;

	public : 
		Rectangle(int count, int base, int vertical) 
		{
			this->lineCount = count;
			this->lengthOfBase = base;
			this->verticalLength = vertical;
;		}

		int area() 
		{
			return lengthOfBase * verticalLength;
		}
};

class Triangle : public Shape 
{
	int height;

public:
	Triangle(int count, int base, int h) 
	{
		this->lineCount = count;
		this->lengthOfBase = base;
		this->height = h;
	}

	int area() 
	{
		return lengthOfBase * height;
	}
};

int main() 
{
	Rectangle r = Rectangle(4, 3, 2);
	Triangle t = Triangle(3, 2, 1);

	std::cout << r.area() << std::endl;
	std::cout << t.area() << std::endl;

	return 0;
}