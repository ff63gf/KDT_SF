#include <iostream>
#include <string>

using namespace std;

int main()
{
	string s = "Police say two people are suspected of trying to create a shortcut for their construction work.The two have been detained and the case is under further investigation.The 38-year-old man and 55-year-old woman were working near the affected area, the 32nd Great Wall.";

	int length = s.length();
	char word = s.at(100);
	int idx1 = s.find("two");
	int idx2 = s.find("two", idx1 + 1);

	cout << length << "  " << word << 
		"  " << idx1 << "  " << idx2 << endl;

	return 0;
}