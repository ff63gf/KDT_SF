#include <iostream>

class Rectnagle {
	int width;
	int height;

	public :
		Rectnagle(int w, int h) {
			width = w;
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

	Rectnagle r = Rectnagle(w, h);
	std::cout << "���̴� : " << r.area();

	return 0;
}