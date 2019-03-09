using System;
using System.Linq;

class Procon {
  public Procon () { }
  static void Main (string[] agrs) {
    new Procon ().Do ();
  }

  Scanner cin;

  public long Calc (long A) {
    long ans = 0;
    long L1 = 1;

    for (int i = 0; i < 40; i++) {
      long loop = L1 << (i + 1);
      long cnt = (A / loop) * (loop / 2);
      cnt += Math.Max (0, (A % loop) - (loop / 2) + 1);
      if (cnt % 2 == 1) {
        ans += (L1 << i);
      }
    }
    return ans;
  }

  public void Do () {
    cin = new Scanner ();
    long a = cin.nextLong ();
    long b = cin.nextLong ();

    Console.WriteLine (Calc (a - 1) ^ Calc (b));
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