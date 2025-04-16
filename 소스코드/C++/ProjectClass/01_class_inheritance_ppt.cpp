//
// 240516, john
// Ŭ���� ��� PPT, ����� ���� ������ ������ ���� �ҽ��ڵ�
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
		// Parent ���뿡 ����
		// 
		// public ���    : Parent���� ������ �Ͱ� �Ȱ��� ���� ����
		// private ���   : Parent���� ������ �Ͱ� �Ȱ��� ���� ����
		// protected ��� : Parent���� ������ �Ͱ� �Ȱ��� ���� ����

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
		// Child�� ���� Parent�� ���뿡 ���� (��� ����)
		// 
		// public ���    : Parent���� ������ �Ͱ� �Ȱ��� ���� ����
		// private ���   : Parent ���뿡 ���� �Ұ�
		// protected ��� : Parent���� ������ �Ͱ� �Ȱ��� ���� ����

		private_var = a;
		public_var = b;
		protected_var = c;
	}
};


int main()
{
	Child child;

	// Child�� ���� Parent�� ���뿡 ����
	// 
	// public ���    : Parent���� ������ �Ͱ� �Ȱ��� ���� ����
	// private ���   : Parent ���뿡 ���� �Ұ�
	// protected ��� : Parent ���뿡 ���� �Ұ�

	child.private_var = 0;
	child.public_var = 0;
	child.protected_var = 0;

	return 0;
}