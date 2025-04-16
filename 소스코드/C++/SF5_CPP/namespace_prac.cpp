#include <iostream>
#include "MyNamespace.h"

namespace Seoul 
{
	int local_num;
	std::string land_mark;
}

namespace Busan
{
	int local_num;
	std::string land_mark;
}

using Busan::land_mark;
using MyNamespace::land_mark;

int main()
{
	Seoul::land_mark = "���빮";
	MyNamespace::land_mark = "���ҽ�Ƽ";

	std::cout << Seoul::land_mark << " " << land_mark << std::endl;

	return 0;
}