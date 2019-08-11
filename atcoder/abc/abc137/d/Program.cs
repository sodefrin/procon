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
        var M = Int ();

        var tuples = L<Tuple<int, int>> ();

        for (int i = 0; i < N; i++) {
            tuples.Add (Tuple.Create (Int (), Int ()));
        }

        var pq = new PriorityQueue<int> (N, false);
        var slist = tuples.OrderBy (v => v.Item1).ToArray ();
        Dbg (slist);

        int cur = 0;
        long ans = 0;
        for (int i = 1; i <= M; i++) {
            while (cur < N && slist[cur].Item1 <= i) {
                pq.Push (slist[cur].Item2);
                cur++;
            }
            if (pq.Count () > 0) {
                Dbg (pq.heap);
                ans += pq.Pop ();
            }
        }

        Console.WriteLine (ans);
        Console.WriteLine (slist);
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
    static void Dbg<T> (IEnumerable<T> a) => Dbg (string.Join (" ", a));
    static T Max<T> (params T[] a) => a.Max ();
    static T Min<T> (params T[] a) => a.Min ();
    static List<T> L<T> () => new List<T> ();
    static List<T> L<T> (T[] v) => new List<T> (v);
    static Dictionary<T, U> Map<T, U> () => new Dictionary<T, U> ();
    static bool Contains<T, U> (Dictionary<T, U> d, T k) => d.ContainsKey (k);
    static Dictionary<T, U>.KeyCollection Keys<T, U> (Dictionary<T, U> d) => d.Keys;
    static Dictionary<T, U>.ValueCollection Values<T, U> (Dictionary<T, U> d) => d.Values;
    static Tuple<T1, T2> T<T1, T2> (T1 t1, T2 t2) => Tuple.Create (t1, t2);
}

class PriorityQueue<T> where T : IComparable<T> {
    public T[] heap;
    public int size;
    public int sign;
    public PriorityQueue (int N, bool order) {
        heap = new T[N];
        if (order) sign = 1;
        else sign = -1;
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
            if (b < size && Compare (heap[b], heap[a]) >= 0) {
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