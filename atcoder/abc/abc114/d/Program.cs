
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
        cin = new Scanner();
        int N = cin.nextInt();
        int[] count = new int[N + 1];

        for (int i = 1; i <= N; i++)
        {
            int tmp = i;
            int j = 2;
            while (true)
            {
                if (j > N)
                {
                    break;
                }
                if (count[j] != 0 && tmp % j == 0)
                {
                    tmp /= j;
                    count[j]++;
                }
                else
                {
                    j++;
                }
            }
            if (tmp != 1)
            {
                count[i] = 1;
            }
        }

        long ans = 0;
        for (int i = 2; i <= N; i++)
        {
            if (count[i] >= 74)
            {
                ans++;
            }
        }

        for (int i = 2; i <= N; i++)
        {
            for (int j = 2; j < N; j++)
            {
                if (i == j)
                {
                    continue;
                }
                if (count[i] >= 14 && count[j] >= 4)
                {
                    ans++;
                }
            }
        }

        for (int i = 2; i <= N; i++)
        {
            for (int j = 2; j < N; j++)
            {
                if (i == j)
                {
                    continue;
                }
                if (count[i] >= 24 && count[j] >= 2)
                {
                    ans++;
                }
            }
        }

        for (int i = 2; i <= N; i++)
        {
            for (int j = 2; j < N; j++)
            {
                if (j == i)
                {
                    continue;
                }
                for (int k = 2; k < N; k++)
                {
                    if (k == j || k == i)
                    {
                        continue;
                    }
                    if (i < j)
                    {
                        continue;
                    }
                    if (count[i] >= 4 && count[j] >= 4 && count[k] >= 2)
                    {
                        ans++;
                    }
                }
            }
        }

        Console.WriteLine(ans);
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
