using System;
using System.Collections.Generic;

class Procon
{
  public Procon() {}
  static void Main(string[] agrs)
  {
    new Procon().Do();
  }

  Scanner cin;

  public void Do()
  {
    cin = new Scanner();
    int N = cin.nextInt();
    int[,] dist = new int[N-1, 3];
    for (int i=0; i<N-1; i++) {
      dist[i,0] = cin.nextInt()-1;
      dist[i,1] = cin.nextInt()-1;
      dist[i,2] = cin.nextInt();
    }
    int Q = cin.nextInt();
    int K = cin.nextInt() - 1;
    long[] d = new long[N];
    for (int i=0; i<N; i++) {
      d[i] = -1;
    }
    d[K] = 0;

    for (int i=0; i<N; i++) { 
      for (int j=0; j<N-1; j++) {
        if (d[dist[j,0]] >= 0) {
          d[dist[j,1]] = d[dist[j,0]] + dist[j, 2];
        } else if (d[dist[j,1]] >= 0) {
          d[dist[j,0]] = d[dist[j,1]] + dist[j, 2];
        }
      }
    }

    // 間違ってる&遅い
    for (int i=0; i<Q; i++) {
      int x = cin.nextInt();
      int y = cin.nextInt();
      Console.WriteLine((long)d[x-1] + (long)d[y-1]);
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
    } else 
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
    for (int i=0; i<str.Length; i++) 
    {
      array[i] = int.Parse(str[i]);
    }
    return array;
  }

  public long[] arrayLong()
  {
    string[] str = Console.ReadLine().Split(' ');
    long[] array = new long[str.Length];
    for (int i=0; i<str.Length; i++) 
    {
      array[i] = long.Parse(str[i]);
    }
    return array;
  }

  public double[] arrayDouble()
  {
    string[] str = Console.ReadLine().Split(' ');
    double[] array = new double[str.Length];
    for (int i=0; i<str.Length; i++) 
    {
      array[i] = double.Parse(str[i]);
    }
    return array;
  }
}
