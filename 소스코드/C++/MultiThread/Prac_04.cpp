// �ǽ�4. �˶��� �︮�� ������
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

    // ���� �Լ�, �Ϲ� �Լ� == return
    cv.wait(lock, [] { return alarm_set; }/*Alarm_set()*/);

    std::cout << "�˶��� �︳�ϴ�!!" << std::endl;
}

int main() {
    int wait_seconds = 5; // 5�� ���
    
    std::cout << "�˶��� ��ٸ��� ��.." << std::endl;

    std::thread timer_thread(timer, wait_seconds);
    std::thread alarm_thread(wait_for_alarm);

    timer_thread.join();
    alarm_thread.join();

    return 0;
}
