#include <iostream>
#include <thread> 

void printMessage() {
    std::cout << "Hello from thread!" << std::endl;
}

int main() {
    std::thread t(printMessage); // ���ο� ������ ����
    t.join(); // ���� �����尡 t �����尡 ����� ������ ���
    return 0;
}

