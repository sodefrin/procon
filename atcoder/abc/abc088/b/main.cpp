#include <bits/stdc++.h>
using namespace std;

int main(int args, char *argv[])
{
  int N;
  cin >> N;
  vector<int> a;

  for (int i = 0; i < N; i++)
  {
    int tmp;
    cin >> tmp;
    a.push_back(tmp);
  }

  sort(a.begin(), a.end());

  int x, y;
  x = 0;
  y = 0;

  for (int i = 0; i < a.size(); i++)
  {
    if (i % 2 == 0)
    {
      x += a[a.size() - 1 - i];
    }
    else
    {
      y += a[a.size() - 1 - i];
    }
  }

  cout << x - y << endl;
}
