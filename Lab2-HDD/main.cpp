#include <unistd.h>
#include <iostream>
using namespace std;
int main()
{
	    execlp("./script.sh",NULL);	
	return 0;
}

