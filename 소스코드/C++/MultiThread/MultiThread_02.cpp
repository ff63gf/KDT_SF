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
    std::thread t1(printMessage, 5, "T1"); // 새로운 스레드 생성 및 입력 값 전달
    std::thread t2(printMessage, 10, "T2"); // 새로운 스레드 생성 및 입력 값 전달

    t1.join(); 
    t2.join(); // 메인 스레드가 t1, t2 스레드가 모두 종료될 때까지 대기
    return 0;
}

