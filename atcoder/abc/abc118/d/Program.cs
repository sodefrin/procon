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

    public void Do()
    {
        int[] costs = new int[9] { 2, 5, 5, 4, 5, 6, 3, 7, 6 };
        cin = new Scanner();
        int N = cin.nextInt();
        int M = cin.nextInt();
        List<int> A = new List<int>(cin.arrayInt());

        int[] DP = new int[N + 1];
        for (int i = 0; i < N; i++)
        {
            DP[i] = -1;
        }

        DP[0] = 0;
        for (int i = 0; i <= N; i++)
        {
            for (int j = 0; j < A.Count(); j++)
            {
                if (i - costs[A[j] - 1] < 0)
                {
                    continue;
                }
                int tmp = DP[i - costs[A[j] - 1]] + 1;
                if (tmp > DP[i])
                {
                    DP[i] = tmp;
                }
            }
        }

        int maxlen = DP[N];
        int tmpN = N;
        A.Sort((a, b) => a - b);
        for (int i = maxlen; i > 0; i--)
        {
            for (int j = A.Count() - 1; j >= 0; j--)
            {
                if (tmpN - costs[A[j] - 1] < 0)
                {
                    continue;
                }
                if (DP[tmpN - costs[A[j] - 1]] + 1 == DP[tmpN])
                {
                    tmpN = tmpN - costs[A[j] - 1];
                    Console.Write(A[j]);
                    break;
                }
            }
        }
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