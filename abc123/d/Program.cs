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
    long X, Y, Z, K;
    long[] A, B, C;

    public void Do()
    {
        cin = new Scanner();
        X = cin.nextLong();
        Y = cin.nextLong();
        Z = cin.nextLong();
        K = cin.nextLong();
        A = cin.arrayLong();
        B = cin.arrayLong();
        C = cin.arrayLong();

        long[] calc1 = new long[X * Y];

        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                calc1[i * Y + j] = A[X - 1 - i] + B[Y - 1 - j];
            }
        }

        Array.Sort(calc1);

        long[] calc2 = new long[K * Z];

        for (int i = 0; i < Math.Min(K, X * Y); i++)
        {
            for (int j = 0; j < Z; j++)
            {
                calc2[i * Z + j] = calc1[X * Y - 1 - i] + C[Z - 1 - j];
            }
        }

        Array.Sort(calc2);

        for (int i = 0; i < K; i++)
        {
            Console.WriteLine(calc2[K * Z - 1 - i]);
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