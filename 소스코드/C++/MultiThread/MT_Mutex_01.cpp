#include <iostream>
#include <thread>
#include <mutex>

// global
std::mutex mtx; // ���ؽ� ��ü ����
int counter = 0; // ���� �ڿ�

void increment() {
    for (int i = 0; i < 100000; ++i) {
        mtx.lock(); // �Ӱ� ������ ���� ���� ���
        ++counter;  // ���� �ڿ��� ����
        mtx.unlock(); // �Ӱ� ������ ����� ��� ����
    }
}

int main() {
    std::thread t1(increment);
    std::thread t2(increment);
    std::thread t3(increment);

    t1.join();
    t2.join();
    t3.join();

    std::cout << "Final counter value: " << counter << std::endl;

    return 0;
}

