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
        int[] A = cin.arrayInt();

        var L = new int[N];
        var R = new int[N + 1];

        L[0] = 0;
        R[N] = 0;
        for (int i = 0; i < N - 1; i++)
        {
            L[i + 1] = gcd(L[i], A[i]);
            R[N - i - 1] = gcd(R[N - i], A[N - i - 1]);
        }

        int max = 0;
        for (int i = 0; i < N; i++)
        {
            int tmp = gcd(L[i], R[i + 1]);
            if (tmp > max)
            {
                max = tmp;
            }
        }

        Console.WriteLine(max);
    }

    int gcd(int a, int b)
    {
        int tmp;
        if (b > a)
        {
            tmp = a;
            a = b;
            b = tmp;
        }

        if (b == 0)
        {
            return a;
        }

        return gcd(b, a % b);
    }

    int gcd(int[] a)
    {
        int ans = a[0];
        for (int i = 1; i < a.Length; i++)
        {
            ans = gcd(ans, a[i]);
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