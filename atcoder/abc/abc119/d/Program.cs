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
        int A = cin.nextInt();
        int B = cin.nextInt();
        int Q = cin.nextInt();

        var s = new long[A];
        var t = new long[B];
        var x = new long[Q];

        for (int i = 0; i < A; i++)
        {
            s[i] = cin.nextLong();
        }

        for (int i = 0; i < B; i++)
        {
            t[i] = cin.nextLong();
        }

        for (int i = 0; i < Q; i++)
        {
            x[i] = cin.nextLong();
        }

        Array.Sort(s);
        Array.Sort(t);

        for (int i = 0; i < Q; i++)
        {
            int s_index = ~Array.BinarySearch(s, x[i]);
            int t_index = ~Array.BinarySearch(t, x[i]);

            long ans = 100000000000;

            if (s_index != 0 && t_index != 0)
            {
                ans = Math.Min(Math.Max(x[i] - s[s_index - 1], x[i] - t[t_index - 1]), ans);
            }
            if (s_index != 0 && t_index != B)
            {
                long tmp = x[i] - s[s_index - 1] + t[t_index] - x[i];
                tmp += Math.Min(x[i] - s[s_index - 1], t[t_index] - x[i]);
                ans = Math.Min(tmp, ans);
            }
            if (t_index != 0 && s_index != A)
            {
                long tmp = s[s_index] - x[i] + x[i] - t[t_index - 1];
                tmp += Math.Min(s[s_index] - x[i], x[i] - t[t_index - 1]);
                ans = Math.Min(tmp, ans);
            }
            if (s_index != A && t_index != B)
            {
                ans = Math.Min(Math.Max(s[s_index] - x[i], t[t_index] - x[i]), ans);
            }

            Console.WriteLine(ans);
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

