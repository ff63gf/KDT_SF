// std::condition_variable ����
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
        std::this_thread::sleep_for(std::chrono::milliseconds(500)); // �۾� ���� �ð�
        std::unique_lock<std::mutex> lock(mtx);
        data_queue.push(i);
        std::cout << "Produced: " << i << std::endl;
        cv.notify_one(); // �����Ͱ� �غ�Ǿ����� �˸�
    }

    // �۾� �ϷḦ �˸�
    // unique_lock ��ü�� ���� �ֱ⸦ �����ϱ� ���� �߰�ȣ(�ڵ� ���)�� ���
    {
        std::unique_lock<std::mutex> lock(mtx);
        done = true;
        cv.notify_all(); // �ٸ� ��� �����带 ����� ������ Ȯ���ϰ� ��
        // condition_variable ��ü�� ����ϴ� �� �ٸ� �����尡 �ϳ��� ���� ���
        // cv.notify_one(); �� ���
    }
}

void consumer() {
    while (true) {
        std::unique_lock<std::mutex> lock(mtx);
        cv.wait(lock, [] { return !data_queue.empty() || done; }); // �����Ͱ� �غ�� ������ ���
        if (!data_queue.empty()) {
            int value = data_queue.front();
            data_queue.pop();
            std::cout << "Consumed: " << value << std::endl;
        }
        else if (done) {
            break; // �����ڰ� �۾��� �������� �˸� ������ ���� ����
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


