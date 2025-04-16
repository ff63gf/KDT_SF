// 240625 John
//
// MySQLConnector 연결 후 테스트
// 
// < Release <-> Debug 빌드 모드 차이점 >
//
// * Debug                                          * Release
// -코드 최적화 없음                                -코드 최적화 수행
// -바이너리(실행 파일) 크기가 큼                    -바이너리 크기가 작음
// -코드 실행 속도가 느림                           -코드 실행 속도 빠름
// -메모리 사용량이 많음                            -메모리 사용량이 적음
// -바이너리에 디버깅에 필요한 정보가 포함됨           -디버깅에 필요한 정보가 거의 포함되지 않음
// -컴파일 속도 빠름                                -컴파일 속도 느림(최적화 하느라)
//
// ** 속도 차이가 10배 정도 생김
// ** 용량 차이는 4배 정도 생김
// ** 보통 개발 중에는 Debug, 실제 사용자에게 전달될 때 Release로 전환
//  
// ** 디버그용 라이브러리와 릴리즈용 라이브러리 혼용하여 사용 불가능 **
// 
//


// MySQLConnector.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <stdlib.h>
#include <iostream>

#include "mysql_connection.h"
#include <cppconn/driver.h>
#include <cppconn/exception.h>
#include <cppconn/prepared_statement.h>
using namespace std;

// for demonstration only. never save your password in the code!
const string server = "tcp://127.0.0.1:3306"; // 데이터베이스 주소
const string username = "user"; // 데이터베이스 사용자
const string password = "1234"; // 데이터베이스 접속 비밀번호


int main()
{
    // MySQL Connector/C++ 초기화
    sql::Driver* driver; // 추후 해제하지 않아도 Connector/C++가 자동으로 해제해 줌
    sql::Connection* con;

    sql::Statement* stmt;
    sql::PreparedStatement* pstmt;

    try
    {
        driver = get_driver_instance();
        con = driver->connect(server, username, password);
    }
    catch (sql::SQLException e)
    {
        cout << "Could not connect to server. Error message: " << e.what() << endl;
        system("pause");
        exit(1);
    }

    // please create database "cpp_db" ahead of time
    con->setSchema("cpp_db");

    // Statement: execute()에 쿼리를 작성하여 바로 실행
    stmt = con->createStatement();
    stmt->execute("DROP TABLE IF EXISTS inventory");
    cout << "Finished dropping table (if existed)" << endl;
    stmt->execute("CREATE TABLE inventory (id serial PRIMARY KEY, name VARCHAR(50), quantity INTEGER);");
    cout << "Finished creating table" << endl;

    // prepareStatement(): SQL문을 DB에 바로 보내지 않고 일부만 작성
    pstmt = con->prepareStatement("INSERT INTO inventory(name, quantity) VALUES(?,?)");

    // setString(), setInt(): 첫 번째 입력값은 prepareStatement()에서 작성한 물음표의 순서
    // 그 밖에 DB에 존해하는 자료형 별로 setXXXX() 메소드들이 존재함

    // ex: setString(1, "banana"): VALUES(?, ?)에서 첫 번째 물음표에 100을 대입
    pstmt->setString(1, "banana");
    // ex: setInt(2, 150): VALUES(?, ?)에서 두 번째 물음표
    pstmt->setInt(2, 150);
    pstmt->execute();
    cout << "One row inserted." << endl;

    // prepareStatement() 입력에 대한 변동이 없다면 물음표 값은 덮어쓰기가 됨
    pstmt->setString(1, "orange");
    pstmt->setInt(2, 154);
    pstmt->execute();
    cout << "One row inserted." << endl;

    pstmt->setString(1, "apple");
    pstmt->setInt(2, 100);
    pstmt->execute();
    cout << "One row inserted." << endl;

    //select  
    pstmt = con->prepareStatement("SELECT * FROM inventory;");
    sql::ResultSet* result = pstmt->executeQuery();

    //sql::ResultSet* result = stmt->executeQuery("SELECT * FROM inventory;");

    while (result->next())
        printf("Reading from table=(%d, %s, %d)\n", result->getInt(1), result->getString(2).c_str(), result->getInt(3));

    //update
    pstmt = con->prepareStatement("UPDATE inventory SET quantity = ? WHERE name = ?");
    pstmt->setInt(1, 200);
    pstmt->setString(2, "banana");
    pstmt->executeQuery();
    printf("Row updated\n");
    
    //delete
    pstmt = con->prepareStatement("DELETE FROM inventory WHERE name = ?");
    pstmt->setString(1, "orange");
    result = pstmt->executeQuery();
    printf("Row deleted\n");

    // MySQL Connector/C++ 정리
    delete result;
    delete stmt;
    delete pstmt;
    delete con;
    system("pause");
    return 0;
}