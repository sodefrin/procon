#include <bits/stdc++.h>
using namespace std;

int main(int args, char *argv[])
{
  int N;
  cin >> N;
  for (int i = 0; i < N; i++)
  {
    string s;
    cin >> s;

    if (s == "Y")
    {
      cout << "Four" << endl;
      return 0;
    }
  }
  cout << "Three" << endl;
  return 0;
}
