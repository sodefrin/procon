#include <bits/stdc++.h>
using namespace std;

int main(int args, char *argv[])
{
  int N;
  cin >> N;
  int A[2][N];
  for (int i = 0; i < 2; i++)
  {
    for (int j = 0; j < N; j++)
    {
      cin >> A[i][j];
    }
  }

  int mx = 0;
  for (int i = 0; i < N; i++)
  {
    int tmp = 0;
    for (int j = 0; j < N; j++)
    {
      if (j <= i)
      {
        tmp += A[0][j];
      }
      if (j >= i)
      {
        tmp += A[1][j];
      }
    }

    if (tmp > mx)
    {
      mx = tmp;
    }
  }

  cout << mx << endl;
  return 0;
}
