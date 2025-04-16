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
	Seoul::land_mark = "남대문";
	MyNamespace::land_mark = "생텀시티";

	std::cout << Seoul::land_mark << " " << land_mark << std::endl;

	return 0;
}