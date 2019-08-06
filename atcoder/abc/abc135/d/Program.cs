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

    List<int> A;

    public void Do()
    {
        cin = new Scanner();
        string S = cin.nextString();
        int N = S.Length;
        A = new List<int>();

        int mod = 0;
        int tmp = 1;
        for (int i = 0; i < N; i++)
        {
            if (S[N - 1 - i] == '?')
            {
                A.Add(tmp);
            }
            else
            {
                int v = S[N - 1 - i] - '0';
                mod = (mod + v * tmp) % 13;
            }
            tmp = (10 * tmp) % 13;
        }


        int M = A.Count;
        int[,] DP = new int[M + 1, 13];

        DP[0, mod] = 1;

        for (int i = 1; i <= M; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                int tmp2 = (j * A[i - 1]) % 13;
                for (int k = 0; k < 13; k++)
                {
                    DP[i, (k + tmp2) % 13] = (DP[i, (k + tmp2) % 13] + DP[i - 1, k]) % 1000000007;
                }
            }
        }

        Console.WriteLine(DP[M, 5]);
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
