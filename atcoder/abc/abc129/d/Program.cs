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

        int H = cin.nextInt();
        int W = cin.nextInt();
        bool[,] b = new bool[H, W];
        for (int i = 0; i < H; i++)
        {
            string tmp = cin.nextString();
            for (int j = 0; j < W; j++)
            {
                if (tmp[j] == '#')
                {
                    b[i, j] = true;
                }
                else
                {
                    b[i, j] = false;
                }
            }
        }

        Node[,] n1 = new Node[H, W];
        for (int i = 0; i < H; i++)
        {
            var parent = new Parent();
            for (int j = 0; j < W; j++)
            {
                n1[i, j] = new Node();
                if (b[i, j])
                {
                    parent = new Parent();
                }
                else
                {
                    n1[i, j].p = parent;
                    parent.num++;
                }
            }
        }

        Node[,] n2 = new Node[H, W];
        for (int j = 0; j < W; j++)
        {
            var parent = new Parent();
            for (int i = 0; i < H; i++)
            {
                n2[i, j] = new Node();
                if (b[i, j])
                {
                    parent = new Parent();
                }
                else
                {
                    n2[i, j].p = parent;
                    parent.num++;
                }
            }
        }

        int max = 0;
        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                if (!b[i, j])
                {
                    int ret = n1[i, j].p.num + n2[i, j].p.num - 1;
                    if (ret > max)
                    {
                        max = ret;
                    }
                }
            }
        }

        Console.WriteLine(max);
    }
}

class Node
{
    public Parent p;
}

class Parent
{
    public int num;
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
