#include <iostream>

class Rectnagle {
	int width;
	int height;

public:
	Rectnagle() {};

	Rectnagle(int w, int h) {
		width = w;
		height = h;
	}

	void setWidth(int w) {
		width = w;
	}

	void setHeight(int h) {
		height = h;
	}

	int area() {
		return width * height;
	}
};


int main() {
	int w;
	int h;
	std::cout << "�簢���� ���ο� ���� ���̸� �Է����ּ���. (����� ����) ";
	std::cin >> w >> h;

	Rectnagle r = Rectnagle();
	r.setWidth(w);
	r.setHeight(h);

	std::cout << "���̴� : " << r.area();

	return 0;
}