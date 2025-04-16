//
// 240516, john
// 클래스 상속 PPT, 상속의 접근 지정자 설명을 위한 소스코드
// 

class Parent
{
private: 
	int private_var = 0;

public:
	int public_var = 0;

protected:
	int protected_var = 0;
};



class Child : protected Parent
{
public:
	Child() {}

	Child(int a, int b, int c)
	{
		// Parent 내용에 접근
		// 
		// public 상속    : Parent에서 정의한 것과 똑같이 접근 가능
		// private 상속   : Parent에서 정의한 것과 똑같이 접근 가능
		// protected 상속 : Parent에서 정의한 것과 똑같이 접근 가능

		private_var = a;
		public_var = b;
		protected_var = c;
	}
};


class ChildOfChild : public Child
{
public:
	ChildOfChild(int a, int b, int c)
	{
		// Child를 거쳐 Parent의 내용에 접근 (상속 관계)
		// 
		// public 상속    : Parent에서 정의한 것과 똑같이 접근 가능
		// private 상속   : Parent 내용에 접근 불가
		// protected 상속 : Parent에서 정의한 것과 똑같이 접근 가능

		private_var = a;
		public_var = b;
		protected_var = c;
	}
};


int main()
{
	Child child;

	// Child를 거쳐 Parent의 내용에 접근
	// 
	// public 상속    : Parent에서 정의한 것과 똑같이 접근 가능
	// private 상속   : Parent 내용에 접근 불가
	// protected 상속 : Parent 내용에 접근 불가

	child.private_var = 0;
	child.public_var = 0;
	child.protected_var = 0;

	return 0;
}