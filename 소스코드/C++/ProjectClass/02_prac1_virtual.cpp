//
// 240516, john
// 클래스 심화 PPT, 실습1 추상 클래스
// 


#include <iostream>

class Shape
{
protected:
	// 순수 가상 함수
	virtual void draw() = 0;
};

class Rectangle : public Shape
{
public:

	void draw()
	{
		std::cout << "도형의 이름은 ""사각형""" << std::endl;
	}
};

class Triangle : public Shape
{
public:
	void draw()
	{
		std::cout << "도형의 이름은 ""삼각형""" << std::endl;
	}
};

class Circle : public Shape
{
public:
	void draw()
	{
		std::cout << "도형의 이름은 ""원""" << std::endl;
	}
};


int main()
{
	Rectangle rectangle;
	Triangle triangle;
	Circle circle; 

	rectangle.draw();
	triangle.draw();
	circle.draw();


	return 0;
}