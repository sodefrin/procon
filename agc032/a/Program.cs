using System;
using System.Collections.Generic;
using System.Linq;

class Program {
  public Program () { }

  Scanner cin;

  int N;

  int[] b;

  static void Main (string[] agrs) {
    new Program ().Do ();
  }

  public void Do () {
    cin = new Scanner ();
    N = cin.nextInt ();
    b = new List<int> (cin.arrayInt ());

    int[] ans = new int[N];

    for (int i = 0; i < N; i++) {
      int max = -1;
      for (int j = 0; j < N; j++) {
        if (b[j] == j + 1) {
          max = j;
        }
      }
      if (max > 0) {
        b.RemoveAt (max);
        ans[i] = max;
      } else {
        Console.WriteLine (max);
        return;
      }
    }

    for (int i = 0; i < N; i++) { }
  }
}

class Scanner {
  string[] s;
  int i;
  int max_i;

  public Scanner () {
    s = new string[0];
    max_i = 0;
    i = 0;
  }

  public string nextString () {
    if (i >= s.Length) {
      s = Console.ReadLine ().Split (' ');
      max_i = s.Length;
      i = 0;
      if (max_i == 0) {
        return "";
      }
      return s[i++];
    } else {
      return s[i++];
    }
  }

  public int nextInt () {
    return int.Parse (nextString ());
  }

  public long nextLong () {
    return long.Parse (nextString ());
  }

  public double nextDouble () {
    return double.Parse (nextString ());
  }

  public string[] arrayString () {
    return Console.ReadLine ().Split (' ');
  }

  public int[] arrayInt () {
    string[] str = Console.ReadLine ().Split (' ');
    int[] array = new int[str.Length];
    for (int i = 0; i < str.Length; i++) {
      array[i] = int.Parse (str[i]);
    }
    return array;
  }

  public long[] arrayLong () {
    string[] str = Console.ReadLine ().Split (' ');
    long[] array = new long[str.Length];
    for (int i = 0; i < str.Length; i++) {
      array[i] = long.Parse (str[i]);
    }
    return array;
  }

  public double[] arrayDouble () {
    string[] str = Console.ReadLine ().Split (' ');
    double[] array = new double[str.Length];
    for (int i = 0; i < str.Length; i++) {
      array[i] = double.Parse (str[i]);
    }
    return array;
  }
}