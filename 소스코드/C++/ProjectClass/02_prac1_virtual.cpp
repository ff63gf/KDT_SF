//
// 240516, john
// Ŭ���� ��ȭ PPT, �ǽ�1 �߻� Ŭ����
// 


#include <iostream>

class Shape
{
protected:
	// ���� ���� �Լ�
	virtual void draw() = 0;
};

class Rectangle : public Shape
{
public:

	void draw()
	{
		std::cout << "������ �̸��� ""�簢��""" << std::endl;
	}
};

class Triangle : public Shape
{
public:
	void draw()
	{
		std::cout << "������ �̸��� ""�ﰢ��""" << std::endl;
	}
};

class Circle : public Shape
{
public:
	void draw()
	{
		std::cout << "������ �̸��� ""��""" << std::endl;
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