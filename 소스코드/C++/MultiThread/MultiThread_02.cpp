#include <iostream>
#include <thread> 
#include <string>

void printMessage(int count, std::string name) {
    for (int i = 0; i < count; i++)
    {
        std::cout << name << ": Hello from thread!" << std::endl;        
    }
}

int main() {
    std::thread t1(printMessage, 5, "T1"); // ���ο� ������ ���� �� �Է� �� ����
    std::thread t2(printMessage, 10, "T2"); // ���ο� ������ ���� �� �Է� �� ����

    t1.join(); 
    t2.join(); // ���� �����尡 t1, t2 �����尡 ��� ����� ������ ���
    return 0;
}

