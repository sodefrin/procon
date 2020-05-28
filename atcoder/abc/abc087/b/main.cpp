#include <bits/stdc++.h>
using namespace std;

int main(int args, char *argv[])
{
  int A, B, C, X;
  cin >> A;
  cin >> B;
  cin >> C;
  cin >> X;

  int ret = 0;
  for (int i = 0; i <= A; i++)
  {
    for (int j = 0; j <= B; j++)
    {
      for (int k = 0; k <= C; k++)
      {
        if (i * 500 + j * 100 + k * 50 == X)
        {
          ret++;
        }
      }
    }
  }

  cout << ret << endl;
}
