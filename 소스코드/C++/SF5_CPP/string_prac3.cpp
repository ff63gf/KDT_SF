#include <iostream>
#include <string>

using namespace std;


int main()
{
	string s = "Codingon";

	s[0] = tolower(s[0]);
	cout << s << endl;

	string sub_string = s.substr(2, 4);
	cout << sub_string << endl;

	s.replace(2, 5, "oooo");
	cout << s << endl;

	s.erase(2, 4);
	cout << s << endl;


	return 0;
}