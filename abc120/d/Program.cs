using System;
using System.Linq;

class Procon {
  public Procon () { }
  static void Main (string[] agrs) {
    new Procon ().Do ();
  }

  Scanner cin;

  public void Update (int[] g, int a, int b, int N) {
    for (int i = 0; i < N; i++) {
      if (g[i] == a) {
        g[i] = b;
      }
    }
  }

  public long Calc (int[] g, int N) {
    int[] num = new int[N];

    for (int i = 0; i < N; i++) {
      num[g[i]]++;
    }

    long ret = N * N;
    for (int i = 0; i < N; i++) {
      ret -= num[i] * num[i];
    }

    return ret / 2;
  }

  public void Do () {
    cin = new Scanner ();
    int N = cin.nextInt ();
    int M = cin.nextInt ();

    int[, ] ab = new int[M, 2];
    for (int i = 0; i < M; i++) {
      ab[i, 0] = cin.nextInt () - 1;
      ab[i, 1] = cin.nextInt () - 1;
    }

    int[] g = new int[N];

    for (int i = 0; i < N; i++) {
      g[i] = i;
    }

    long[] retarray = new long[M];
    for (int i = 0; i < M; i++) {
      long ret = Calc (g, N);
      retarray[M - i - 1] = ret;
      int a = ab[M - i - 1, 0];
      int b = ab[M - i - 1, 1];
      if (g[a] == g[b]) {
        continue;
      }
      Update (g, g[a], g[b], N);
    }

    for (int i = 0; i < M; i++) {
      Console.WriteLine (retarray[i]);
    }
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