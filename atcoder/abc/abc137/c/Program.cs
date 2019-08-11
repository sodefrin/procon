using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

class Procon {
    static void Main (string[] agrs) {
        var N = Int ();
        var d = Map<string, long> ();
        for (int i = 0; i < N; i++) {
            var c = Chars ();
            Array.Sort (c);
            var s = new String (c);
            if (!Contains (d, s)) {
                d.Add (s, 1);
            } else {
                d[s]++;
            }
        }

        long ans = 0;
        foreach (var v in Values (d)) {
            ans += v * (v - 1) / 2;
        }

        Dbg (ans);
    }

    static Scanner cin = new Scanner ();
    const int M = 1000000007;
    static void Dbg (object a) => Console.WriteLine (a);
    static void Dbg (string a) => Console.WriteLine (a);
    static void Dbg<T> (IEnumerable<T> a) => Dbg (string.Join (" ", a));
    static void Dbg<T> (params object[] a) => Dbg (string.Join (" ", a));
    static void Dbgs<T> (IEnumerable<T> a) => Dbg (string.Join ("\n", a));
    static void Dbgs<T> (params object[] a) => Dbg (string.Join ("\n", a));
    static int Int () => cin.nextInt ();
    static long Long () => cin.nextLong ();
    static int[] Ints () => cin.arrayInt ();
    static long[] Longs () => cin.arrayLong ();
    static double Double () => cin.nextDouble ();
    static double[] Doubles () => cin.arrayDouble ();
    static string String () => cin.nextString ();
    static string[] Strings () => cin.arrayString ();
    static char[] Chars () => String ().ToCharArray ();
    static T Max<T> (params T[] a) => a.Max ();
    static T Min<T> (params T[] a) => a.Min ();
    static List<T> L<T> () => new List<T> ();
    static List<T> L<T> (T[] v) => new List<T> (v);
    static Dictionary<T, U> Map<T, U> () => new Dictionary<T, U> ();
    static bool Contains<T, U> (Dictionary<T, U> d, T k) => d.ContainsKey (k);
    static Dictionary<T, U>.KeyCollection Keys<T, U> (Dictionary<T, U> d) => d.Keys;
    static Dictionary<T, U>.ValueCollection Values<T, U> (Dictionary<T, U> d) => d.Values;
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