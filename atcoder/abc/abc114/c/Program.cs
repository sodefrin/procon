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
        long N = cin.nextInt();
        Console.WriteLine(dfs(N, 0));
    }

    long dfs(long N, long cur)
    {
        if (cur > N)
        {
            return 0;
        }

        long tmp = 0;
        tmp += dfs(N, cur * 10 + 7);
        tmp += dfs(N, cur * 10 + 5);
        tmp += dfs(N, cur * 10 + 3);

        bool have3 = false;
        bool have5 = false;
        bool have7 = false;
        while (true)
        {
            if (cur == 0)
            {
                break;
            }
            if (cur % 10 == 3)
            {
                have3 = true;
            }
            if (cur % 10 == 5)
            {
                have5 = true;
            }
            if (cur % 10 == 7)
            {
                have7 = true;
            }
            cur /= 10;
        }
        if (have3 && have5 && have7)
        {
            tmp++;
        }
        return tmp;
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
