// std::condition_variable 사용법
// 24.06.20 john

#include <iostream>
#include <thread>
#include <mutex>
#include <condition_variable>
#include <queue>

std::mutex mtx;
std::condition_variable cv;
std::queue<int> data_queue;
bool done = false;

void producer() {
    for (int i = 0; i < 10; ++i) {
        std::this_thread::sleep_for(std::chrono::milliseconds(500)); // 작업 지연 시간
        std::unique_lock<std::mutex> lock(mtx);
        data_queue.push(i);
        std::cout << "Produced: " << i << std::endl;
        cv.notify_one(); // 데이터가 준비되었음을 알림
    }

    // 작업 완료를 알림
    // unique_lock 객체의 생명 주기를 조절하기 위해 중괄호(코드 블록)을 사용
    {
        std::unique_lock<std::mutex> lock(mtx);
        done = true;
        cv.notify_all(); // 다른 모든 스레드를 깨우고 조건을 확인하게 함
        // condition_variable 객체를 사용하는 또 다른 스레드가 하나만 있을 경우
        // cv.notify_one(); 을 사용
    }
}

void consumer() {
    while (true) {
        std::unique_lock<std::mutex> lock(mtx);
        cv.wait(lock, [] { return !data_queue.empty() || done; }); // 데이터가 준비될 때까지 대기
        if (!data_queue.empty()) {
            int value = data_queue.front();
            data_queue.pop();
            std::cout << "Consumed: " << value << std::endl;
        }
        else if (done) {
            break; // 생산자가 작업을 마쳤음을 알림 받으면 루프 종료
        }
    }
}

int main() {
    std::thread producer_thread(producer);
    std::thread consumer_thread(consumer);

    producer_thread.join();
    consumer_thread.join();

    return 0;
}


