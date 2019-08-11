using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

class Procon {
    static void Main (string[] agrs) {
        int N = Int ();
        int M = Int ();

        var tuples = new List<Tuple<int, int>> ();

        for (int i = 0; i < N; i++) {
            tuples.Add (Tuple.Create (Int (), Int ()));
        }

        var sorted = tuples.OrderBy (v => v.Item1).ToList ();
        var pq = new PriorityQueue<int> (N, true);

        int cur = 0;
        int ans = 0;
        for (int i = 1; i <= M; i++) {
            while (cur < N && sorted[cur].Item1 <= i) {
                pq.Push (sorted[cur].Item2);
                cur++;
            }
            if (pq.Count () > 0) {
                ans += pq.Pop ();
            }
        }
        Dbg (ans);
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