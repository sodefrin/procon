#include <iostream>
#include <map>
#include <string.h>
using namespace std;

int main(int args, char *argv[])
{
    map<string, int> cnt;

    int N;
    cin >> N;
    for (int i = 0; i < N; i++)
    {
        string tmp;
        cin >> tmp;
        cnt[tmp]++;
    }

    int M;
    cin >> M;
    for (int i = 0; i < M; i++)
    {
        string tmp;
        cin >> tmp;
        cnt[tmp]--;
    }

    int m;
    for (auto it = cnt.begin(); it != cnt.end(); ++it)
    {
        m = max(m, it->second);
    }

    cout << m << endl;
    return 0;
}
