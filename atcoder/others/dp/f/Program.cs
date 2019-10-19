using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

class Procon {
    static void Main (string[] agrs) {
        var s = String ();
        var t = String ();

        var S = s.Length;
        var T = t.Length;

        int[, ] DP = new int[S + 1, T + 1];

        for (int i = 0; i < S; i++) {
            for (int j = 0; j < T; j++) {
                if (s[i] == t[j]) {
                    DP[i + 1, j + 1] = DP[i, j] + 1;
                } else {
                    DP[i + 1, j + 1] = Max (DP[i + 1, j], DP[i, j + 1]);
                }
            }
        }

        int cur_i = S;
        int cur_j = T;
        string ans = "";
        while (true) {
            if (cur_j - 1 >= 0 && DP[cur_i, cur_j] == DP[cur_i, cur_j - 1]) {
                cur_j--;
            } else if (cur_i - 1 >= 0 && DP[cur_i, cur_j] == DP[cur_i - 1, cur_j]) {
                cur_i--;
            } else {
                cur_i--;
                cur_j--;
                ans += s[cur_i];
            }
            if (cur_i == 0 && cur_j == 0) {
                break;
            }
        }

        Dbg (new string (ans.Reverse ().ToArray ()));
    }

    static string String () => Scanner.nextString ();
    static int Int () => int.Parse (Scanner.nextString ());
    static long Long () => long.Parse (Scanner.nextString ());
    static double Double () => double.Parse (Scanner.nextString ());
    static char[] Chars () => String ().ToCharArray ();
    static string[] Strings () => Console.ReadLine ().Split (' ');
    static int[] Ints () => Strings ().Select (v => int.Parse (v)).ToArray ();
    static long[] Longs () => Strings ().Select (v => long.Parse (v)).ToArray ();
    static double[] Doubles () => Strings ().Select (v => double.Parse (v)).ToArray ();
    const int M = 1000000007;
    static void Dbg (object a) => Console.WriteLine (a);
    static void Dbg (params object[] a) => Console.WriteLine (string.Join (" ", a));
    static void Dbgs<T> (IEnumerable<T> a, string split = " ") => Console.WriteLine (string.Join (split, a));
    static T Max<T> (params T[] a) => a.Max ();
    static T Min<T> (params T[] a) => a.Min ();
}

class PriorityQueue<T> where T : IComparable<T> {
    public T[] heap;
    public int size;
    public int sign;
    public PriorityQueue (int N, bool descend = false) {
        heap = new T[N];
        if (descend) sign = -1;
    }
    public int Compare (T x, T y) {
        return x.CompareTo (y) * sign;
    }
    public void Push (T x) {
        int i = size++;
        while (i > 0) {
            int p = (i - 1) / 2;
            if (Compare (x, heap[p]) >= 0) {
                break;
            }
            heap[i] = heap[p];
            i = p;
        }
        heap[i] = x;
    }
    public T Pop () {
        T ret = heap[0];
        T x = heap[--size];
        int i = 0;
        while (i * 2 + 1 < size) {
            int a = i * 2 + 1;
            int b = i * 2 + 2;
            if (b < size && Compare (heap[a], heap[b]) > 0) {
                a = b;
            }
            if (Compare (heap[a], x) >= 0) {
                break;
            }
            heap[i] = heap[a];
            i = a;
        }
        heap[i] = x;
        return ret;
    }
    public int Count () {
        return size;
    }
}

class Scanner {
    static string[] s = new string[0];
    static int i = 0;
    static int max_i = 0;
    static public string nextString () {
        if (i >= s.Length) {
            s = Console.ReadLine ().Split (' ');
            max_i = s.Length;
            i = 0;
            if (max_i == 0) {
                return "";
            }
            return s[i++];
        }
        return s[i++];
    }
}