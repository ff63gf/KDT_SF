#include <iostream>
#include <thread> 

void printMessage() {
    std::cout << "Hello from thread!" << std::endl;
}

int main() {
    std::thread t(printMessage); // 새로운 스레드 생성
    t.join(); // 메인 스레드가 t 스레드가 종료될 때까지 대기
    return 0;
}

