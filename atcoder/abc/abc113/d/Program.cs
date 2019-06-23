using System;
using System.Collections.Generic;
using System.Linq;

class Procon
{
    public Procon() { }
    static void Main(string[] agrs)
    {
        new Procon().Do();
    }

    Scanner cin;

    int H;
    int W;
    int K;

    long M = 1000000007;

    public void Do()
    {
        cin = new Scanner();
        H = cin.nextInt();
        W = cin.nextInt();
        K = cin.nextInt();

        long[,] DP = new long[H + 1, W];

        DP[0, 0] = 1;
        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                for (int k = 0; k < 1 << (W - 1); k++)
                {
                    bool ok = true;
                    for (int l = 0; l < W - 2; l++)
                    {
                        if (((k >> l & 1) == 1) && ((k >> (l + 1) & 1) == 1))
                        {
                            ok = false;
                        }
                    }
                    if (ok)
                    {
                        if (j >= 1 && ((k >> (j - 1)) & 1) == 1)
                        {
                            DP[i + 1, j - 1] += DP[i, j];
                            DP[i + 1, j - 1] %= M;
                        }
                        else if (j <= W - 2 && ((k >> j) & 1) == 1)
                        {
                            DP[i + 1, j + 1] += DP[i, j];
                            DP[i + 1, j + 1] %= M;
                        }
                        else
                        {
                            DP[i + 1, j] += DP[i, j];
                            DP[i + 1, j] %= M;
                        }
                    }
                }
            }
        }

        Console.WriteLine(DP[H, K - 1]);
    }

    public long pow(long a, long b)
    {
        long ans = 1;
        for (int i = 0; i < b; i++)
        {
            ans = (ans * a) % M;
        }

        return ans;
    }
}

class Scanner
{
    string[] s;
    int i;
    int max_i;

    public Scanner()
    {
        s = new string[0];
        max_i = 0;
        i = 0;
    }

    public string nextString()
    {
        if (i >= s.Length)
        {
            s = Console.ReadLine().Split(' ');
            max_i = s.Length;
            i = 0;
            if (max_i == 0)
            {
                return "";
            }
            return s[i++];
        }
        else
        {
            return s[i++];
        }
    }

    public int nextInt()
    {
        return int.Parse(nextString());
    }


    public long nextLong()
    {
        return long.Parse(nextString());
    }

    public double nextDouble()
    {
        return double.Parse(nextString());
    }

    public string[] arrayString()
    {
        return Console.ReadLine().Split(' ');
    }

    public int[] arrayInt()
    {
        string[] str = Console.ReadLine().Split(' ');
        int[] array = new int[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            array[i] = int.Parse(str[i]);
        }
        return array;
    }

    public long[] arrayLong()
    {
        string[] str = Console.ReadLine().Split(' ');
        long[] array = new long[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            array[i] = long.Parse(str[i]);
        }
        return array;
    }

    public double[] arrayDouble()
    {
        string[] str = Console.ReadLine().Split(' ');
        double[] array = new double[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            array[i] = double.Parse(str[i]);
        }
        return array;
    }
}
