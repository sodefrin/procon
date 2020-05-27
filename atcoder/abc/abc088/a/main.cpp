#include <bits/stdc++.h>
using namespace std;

int main(int args, char *argv[])
{
  int N, A;

  cin >> N;
  cin >> A;

  if (N % 500 <= A)
  {
    cout << "Yes" << endl;
  }
  else
  {
    cout << "No" << endl;
  }

  return 0;
}
