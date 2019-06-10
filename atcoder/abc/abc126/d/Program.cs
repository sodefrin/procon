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
    int[] ans;
    Node[] node;

    public void Do()
    {
        cin = new Scanner();
        int N = cin.nextInt();
        ans = new int[N];
        node = new Node[N];

        for (int i = 0; i < N; i++)
        {
            node[i] = new Node();
            node[i].e = new List<Edge>();
            ans[i] = -1;
        }

        for (int i = 0; i < N - 1; i++)
        {
            int u = cin.nextInt();
            int v = cin.nextInt();
            int w = cin.nextInt();

            var e1 = new Edge();
            e1.from = u - 1;
            e1.to = v - 1;
            e1.w = w;
            node[u - 1].e.Add(e1);

            var e2 = new Edge();
            e2.from = v - 1;
            e2.to = u - 1;
            e2.w = w;
            node[v - 1].e.Add(e2);
        }

        dfs(0, 0);

        for (int i = 0; i < N; i++)
        {
            if (ans[i] % 2 == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine("1");
            }
        }
    }

    void dfs(int i, int val)
    {
        if (ans[i] != -1)
        {
            return;
        }
        ans[i] = val;

        foreach (Edge e in node[i].e)
        {
            dfs(e.to, val + e.w);
        }
    }
}

class Node
{
    public List<Edge> e;
}

class Edge
{
    public int from;
    public int to;
    public int w;
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