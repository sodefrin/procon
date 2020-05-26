#include <bits/stdc++.h>
using namespace std;

int main(int args, char *argv[])
{

    int N;
    cin >> N;

    vector<pair<int, int>> v1;
    for (int i = 0; i < N; i++)
    {
        int a, b;
        cin >> a;
        cin >> b;
        v1.push_back({a, b});
    }

    vector<pair<int, int>> v2;
    for (int i = 0; i < N; i++)
    {
        int c, d;
        cin >> c;
        cin >> d;
        v2.push_back({c, d});
    }

    sort(v1.begin(), v1.end());
    sort(v2.begin(), v2.end());

    map<int, bool> tmp1;
    map<int, bool> tmp2;
    int ret = 0;

    for (int j = 0; j < v2.size(); j++)
    {
        int mx = -1;
        int tmp = 0;
        for (int i = v1.size() - 1; i >= 0; i--)
        {
            if (v1[i].first < v2[j].first && v1[i].second < v2[j].second)
            {
                if (!tmp1[i] && !tmp2[j])
                {
                    if (v1[i].second >= tmp)
                    {
                        mx = i;
                        tmp = v1[i].second;
                    }
                }
            }
        }

        if (mx >= 0)
        {
            tmp1[mx] = true;
            tmp2[j] = true;
            ret++;
        }
    }

    cout << ret << endl;
}
