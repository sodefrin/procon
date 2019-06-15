using System;
using System.Linq;

class Procon
{
    public Procon() { }
    static void Main(string[] agrs)
    {
        new Procon().Do();
    }

    Scanner cin;

    long N;
    long K;
    long[] count;

    bool[] binaryK;

    public void Do()
    {
        cin = new Scanner();
        N = cin.nextInt();
        K = cin.nextLong();
        count = new long[40];

        for (long i = 0; i < N; i++)
        {
            long A = cin.nextLong();

            for (int j = 0; j < 40; j++)
            {
                count[j] += A & (long)1;
                A = A >> 1;
            }
        }

        binaryK = new bool[40];
        long tmp = K;
        for (int i = 0; i < 40; i++)
        {
            if ((tmp & (long)1) == 1)
            {
                binaryK[i] = true;
            }
            else
            {
                binaryK[i] = false;
            }
            tmp = tmp >> 1;
        }

        long max = 0;
        tmp = 0;
        for (int i = 1; i <= 40; i++)
        {
            if (binaryK[40 - i])
            {
                max = Math.Max(sum(i) + tmp + pow(40 - i) * (count[40 - i]), max);
                tmp += pow(40 - i) * (N - count[40 - i]);
            }
            else
            {
                tmp += pow(40 - i) * count[40 - i];
            }
        }

        Console.WriteLine(Math.Max(max, tmp));
    }

    long sum(int padding)
    {
        long ret = 0;
        long tmp = 1;
        for (int i = 0; i < 40 - padding; i++)
        {
            ret += tmp * Math.Max(count[i], N - count[i]);
            tmp *= 2;
        }
        return ret;
    }

    long pow(int n)
    {
        long ret = 1;
        for (int i = 0; i < n; i++)
        {
            ret *= 2;
        }
        return ret;
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
