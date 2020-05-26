#include <bits/stdc++.h>
using namespace std;

int main(int args, char *argv[])
{
  int N;
  cin >> N;
  long long x[5] = {0};

  for (int i = 0; i < N; i++)
  {
    string s;
    cin >> s;
    if (s[0] == 'M')
    {
      x[0]++;
    }
    if (s[0] == 'A')
    {
      x[1]++;
    }
    if (s[0] == 'R')
    {
      x[2]++;
    }
    if (s[0] == 'C')
    {
      x[3]++;
    }
    if (s[0] == 'H')
    {
      x[4]++;
    }
  }

  long long ret = 0;
  for (int i = 0; i < 5; i++)
  {
    for (int j = i + 1; j < 5; j++)
    {
      for (int k = j + 1; k < 5; k++)
      {
        ret += x[i] * x[j] * x[k];
      }
    }
  }

  cout << ret << endl;
  return 0;
}
