#include <iostream>

using std::cout;
using std::cin;
using std::endl;
using std::string;

class Operation {
protected:
    double num1, num2;
    static double result;

public:
    Operation(double num1, double num2) {
        this->num1 = num1;
        this->num2 = num2;
    }

    virtual void calculate() = 0;

    static double getResult() {
        return result;
    }
};

double Operation::result = 0;

class Add : public Operation {
public:
    Add(double num1, double num2) : Operation(num1, num2) {};
    void calculate() {
        result = num1 + num2;
    }
};

class Minus : public Operation {
public:
    Minus(double num1, double num2) : Operation(num1, num2) {};
    void calculate() {
        result = num1 - num2;
    }
};

class Multiply : public Operation {
public:
    Multiply(double num1, double num2) : Operation(num1, num2) {};
    void calculate() {
        result = num1 * num2;
    }
};

class Divide : public Operation {
public:
    Divide(double num1, double num2) : Operation(num1, num2) {};
    void calculate() {
        result = num1 / num2;
    }
};

double input_double() {
    double num;
    cout << "숫자를 입력해주세요 : ";
    cin >> num;
    
    return num;
}


int main()
{
    char op;
    double number[2] = {};
    double num_in;
    Operation* operation;
    string isContinue = "AC";

    while (1) {

        if (isContinue == "EXIT") break;
        else if (isContinue == "AC") {
            number[0] = input_double();
        }

        cout << "연산자를 입력해주세요 : ";
        cin >> op;

        number[1] = input_double();

        switch (op) {
        case '+':
            operation = new Add(number[0], number[1]);
            break;
        case '-':
            operation = new Minus(number[0], number[1]);
            break;
        case '*':
            operation = new Multiply(number[0], number[1]);
            break;
        default:
            operation = new Divide(number[0], number[1]);

            break;
        }

        operation->calculate();
        number[0] = Operation::getResult();
        delete operation;
        cout << "------------------------------------------------------\n";
        cout << "결과 : " << Operation::getResult() << endl;
        cout << "------------------------------------------------------\n";

        cout << "연산을 계속 진행하시겠습니까? (Y: 계속, AC: 초기화, EXIT: 종료) ";
        cin >> isContinue;
    }

    return 0;
}