#include <bits/stdc++.h>
using namespace std;

int main(int args, char *argv[])
{
  int X, A, B;
  cin >> X;
  cin >> A;
  cin >> B;

  cout << (X - A) % B << endl;
  return 0;
}
