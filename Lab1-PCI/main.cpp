#include <unistd.h>
#include <iostream>
using namespace std;
int main()
{

	    execlp("/usr/bin/gnome-terminal","-x","-x","lspci","-vmm",NULL);
			
	return 0;
}


