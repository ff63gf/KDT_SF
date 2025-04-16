﻿//Dev. BlockDMask
//Blog. https://blockdmask.tistory.com/
#include<iostream>
#include<Windows.h>
#include<conio.h>
using namespace std;
#define INIT_POS 1
//-----------------------------------------
//콘솔 내부의 특정 위치로 커서를 이동하는 함수.
void GotoXY(int x, int y)
{
	COORD pos;
	pos.X = 2 * x;
	pos.Y = y;
	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), pos);
}

//콘솔 창 크기와 제목을 관리하는 함수.
void SetConsoleView()
{
	system("mode con:cols=65 lines=10");
	system("title Card Matching Game. by BlockDmask.");
}

//키보드 입력 감지 및 입력된 키보드를 반환하는 함수.
int GetKeyDown()
{
	if (_kbhit() != 0)
	{
		return _getch();
	}
	return 0;
}
//-----------------------------------------
//2차원 배열로 이루어진 맵
const int originMap[4][4] = { {1, 6, 1, 8},
								{6, 2, 5, 4},
								{7, 2, 5, 4},
								{8, 3, 3, 7} };

//포지션 구조체
struct Pos
{
	int x;
	int y;
};

//키보드 입력을 저장해 놓은 enum
enum KEYBOARD
{
	IS_ARROW = 224,
	UP = 72,
	LEFT = 75,
	RIGHT = 77,
	DOWN = 80,
	SPACE = 32,
};

//색상을 저장해놓은 enum
enum COLOR
{
	GREEN = 10,
	MINT,
	RED,
	PINK,
	YELLOW,
	WHITE,
};

//게임 매니저 클래스
class GameManager
{
private:
	char questionMap[4][4];	//맞추고 있는 맵.
	Pos player;				//플레이어 커서 위치.
	Pos flipPos[2];			//뒤집은 카드 위치 저장.
	int flipCount;			//뒤집은 카드 개수.
	int spaceCount;			//뒤집은 횟수.
	int matchedCardCount;	//맞춘 카드 개수.
public:
	void StartGame()
	{
		Init();		//게임 초기화
		DrawBack();	//배경 그리기

		//게임 루프 시작
		int key = 0;
		while (true)
		{
			key = GetKeyDown();	//키 입력 받는 함수
			if (key == KEYBOARD::IS_ARROW)
			{
				//화살표들.
				MovePos();
			}
			if (key == KEYBOARD::SPACE)
			{
				//스페이스
				FlipCard();
			}
			//draw
			DrawMain();
			Sleep(100);
			CheckCard();
		}
	}

	//맵 초기화
	void Init()
	{
		for (int y = 0; y < 4; ++y)
		{
			for (int x = 0; x < 4; ++x)
			{
				questionMap[y][x] = '?';	//물음표로 다 세팅
			}
		}
		player.x = 0;
		player.y = 0;
		flipCount = 0;
		spaceCount = 0;
		matchedCardCount = 0;
	}

	//카드 뒤집는 함수
	void FlipCard()
	{
		if (questionMap[player.y][player.x] != '?') return;
		if (flipCount > 2) return;
		flipPos[flipCount].x = player.x;
		flipPos[flipCount].y = player.y;
		questionMap[player.y][player.x] = originMap[player.y][player.x] + '0';
		++flipCount;
	}

	//커서의 위치 이동
	void MovePos()
	{
		GotoXY(INIT_POS + (player.x * 3), INIT_POS + (player.y * 2) + 1);
		printf("  ");

		//키보드 입력을 받아서, 해당 위치로 이동을 시켜준다.
		switch (_getch())
		{
		case KEYBOARD::LEFT:
			--player.x;
			if (player.x <= 0)
			{
				player.x = 0;
			}
			break;
		case KEYBOARD::RIGHT:
			++player.x;
			if (player.x >= 3)
			{
				player.x = 3;
			}
			break;
		case KEYBOARD::UP:
			--player.y;
			if (player.y <= 0)
			{
				player.y = 0;
			}
			break;
		case KEYBOARD::DOWN:
			++player.y;
			if (player.y >= 3)
			{
				player.y = 3;
			}
			break;
		}
	}

	void DrawMain()
	{
		//map draw
		SetTextColor(WHITE);
		char c = '\0';
		for (int y = 0; y < 4; ++y)
		{
			GotoXY(INIT_POS, INIT_POS + (2 * y));
			for (int x = 0; x < 4; ++x)
			{
				c = questionMap[y][x];
				if (c != '?')
				{
					SetTextColor(GREEN);
				}
				printf("[%c]   ", c);
				SetTextColor(WHITE);
			}
		}

		//player draw
		GotoXY(INIT_POS + (player.x * 3), INIT_POS + (player.y * 2) + 1);
		printf(" ^");

		GotoXY(14, 1);
		printf("Count : %d", spaceCount);
	}

	void CheckCard()
	{
		if (flipCount == 2)
		{
			char c = '?';
			if (originMap[flipPos[0].y][flipPos[0].x] == originMap[flipPos[1].y][flipPos[1].x])
			{
				//같을때
				c = originMap[flipPos[0].y][flipPos[0].x] + '0';
				++matchedCardCount;
			}
			else
			{
				//다를때.
				Sleep(500);
			}
			questionMap[flipPos[0].y][flipPos[0].x] = c;
			questionMap[flipPos[1].y][flipPos[1].x] = c;
			flipCount = 0;
			++spaceCount;

			if (matchedCardCount >= 8)
			{
				DrawGameClear();
				Sleep(2000);
				system("cls");
				Init();
				DrawBack();
			}
		}
	}

	void DrawBack()
	{
		SetTextColor(WHITE);
		GotoXY(14, 6);
		cout << "https://blockdmask.tistory.com/";
		GotoXY(14, 7);
		cout << "_by. ";
		SetTextColor(PINK);
		cout << "BlockDMask";
		SetTextColor(WHITE);
	}

	void DrawGameClear()
	{
		SetTextColor(YELLOW);
		GotoXY(10, 3);
		cout << "=========================";
		GotoXY(10, 4);
		cout << "======= C L E A R =======";
		GotoXY(10, 5);
		cout << "=========================";
		SetTextColor(WHITE);
	}

	void SetTextColor(int color)
	{
		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), color);
	}
};

//메인함수
int main(void)
{
	SetConsoleView();
	GameManager* pGameMgr = new GameManager();
	pGameMgr->StartGame();
	delete(pGameMgr);
	return 0;
}