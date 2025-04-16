// 실습4. 알람을 울리는 스레드
// 24.06.20 john

#include <iostream>
#include <thread>
#include <mutex>
#include <condition_variable>
#include <chrono>

std::mutex mtx;
std::condition_variable cv;
bool alarm_set = false;

bool Alarm_set()
{
    return alarm_set;
}

void timer(int wait_seconds) {
    std::this_thread::sleep_for(std::chrono::seconds(wait_seconds));

    std::unique_lock<std::mutex> lock(mtx);
    alarm_set = true;
    cv.notify_one();
}

void wait_for_alarm() {
    std::unique_lock<std::mutex> lock(mtx);

    // 람다 함수, 일반 함수 == return
    cv.wait(lock, [] { return alarm_set; }/*Alarm_set()*/);

    std::cout << "알람이 울립니다!!" << std::endl;
}

int main() {
    int wait_seconds = 5; // 5초 대기
    
    std::cout << "알람을 기다리는 중.." << std::endl;

    std::thread timer_thread(timer, wait_seconds);
    std::thread alarm_thread(wait_for_alarm);

    timer_thread.join();
    alarm_thread.join();

    return 0;
}
