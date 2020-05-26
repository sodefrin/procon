#include <iostream>
#include <string.h>
using namespace std;

int main(int args, char *argv[])
{
    int a, b, c;
    cin >> a;
    cin >> b;
    cin >> c;

    if (a + b >= c)
    {
        cout << "Yes" << endl;
    }
    else
    {
        cout << "No" << endl;
    }
}
