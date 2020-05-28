#include <bits/stdc++.h>
using namespace std;

int main(int args, char *argv[])
{
  string a, b, c;
  cin >> a;
  cin >> b;

  int x = atoi((a + b).c_str());

  for (int i = 0; i < 318; i++)
  {
    if (x == i * i)
    {
      cout << "Yes" << endl;
      return 0;
    }
  }
  cout << "No" << endl;
  return 0;
}
