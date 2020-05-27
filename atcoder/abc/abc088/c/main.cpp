#include <bits/stdc++.h>
using namespace std;

int main(int args, char *argv[])
{
  int c[3][3];

  for (int i = 0; i < 3; i++)
  {
    for (int j = 0; j < 3; j++)
    {
      cin >> c[i][j];
    }
  }

  for (int i = 0; i < 2; i++)
  {
    int tmp = c[i][0] - c[i + 1][0];
    for (int j = 1; j < 3; j++)
    {
      if (tmp != c[i][j] - c[i + 1][j])
      {
        cout << "No" << endl;
        return 0;
      }
    }
  }

  for (int i = 0; i < 2; i++)
  {
    int tmp = c[0][i] - c[0][i + 1];
    for (int j = 1; j < 3; j++)
    {
      if (tmp != c[j][i] - c[j][i + 1])
      {
        cout << "No" << endl;
        return 0;
      }
    }
  }

  cout << "Yes" << endl;
  return 0;
}
