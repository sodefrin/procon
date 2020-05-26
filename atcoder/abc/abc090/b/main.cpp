#include <bits/stdc++.h>
using namespace std;

int main(int args, char *argv[])
{
  int a, b;
  cin >> a;
  cin >> b;

  int ret = 0;
  for (int i = a; i <= b; i++)
  {
    string str;
    bool ok = false;
    str = to_string(i);
    for (int j = 0; j < str.size() / 2; j++)
    {
      if (str[j] != str[str.size() - 1 - j])
      {
        ok = true;
      }
    }

    if (!ok)
    {
      ret++;
    }
  }

  cout << ret << endl;
  return 0;
}
