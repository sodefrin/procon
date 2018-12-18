using System;
using System.Linq;

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
    int[] r = new int[4];
    r[0] = 0;
    r[1] = 1;
    r[2] = 2;
    r[3] = 3;
  }

  public static bool next_permutation<T>(T[] array) where T : IComparable<T> 
  {
    int end = array.Length - 1;
    int last = end;
    while (true)
    {
      int pos = last - 1;
      if (array[pos].CompareTo(array[last]) < 0)
      {
        int i;
        for (i=end;; i--) {
          if (array[pos].CompareTo(array[i])<0) {
            break;
          }
        }
        T tmp = array[pos];
        array[pos] = array[i];
        array[i] = tmp;
        Array.Reverse(array, last, end - last + 1);
        return true;
      }
      last --;
      if (last == 0 )
      {
        return false;
      }
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
    if (i >= s.Length) {
      s = Console.ReadLine().Split(' ');
      max_i = s.Length;
      if (max_i == 0) {
        return "";
      }
      return s[i++];
    } else {
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
    for (int i=0; i<str.Length; i++) {
      array[i] = int.Parse(str[i]);
    }
    return array;
  }

  public long[] arrayLong()
  {
    string[] str = Console.ReadLine().Split(' ');
    long[] array = new long[str.Length];
    for (int i=0; i<str.Length; i++) {
      array[i] = long.Parse(str[i]);
    }
    return array;
  }

  public double[] arrayDouble()
  {
    string[] str = Console.ReadLine().Split(' ');
    double[] array = new double[str.Length];
    for (int i=0; i<str.Length; i++) {
      array[i] = double.Parse(str[i]);
    }
    return array;
  }
}
