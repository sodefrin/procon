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

        List<Tuple<int, int>> e = new List<Tuple<int, int>> ();

        for (int i = 0; i < M; i++) {
            e.Add (Tuple.Create (Int (), Int ()));
        }

        var nodes = new Node[N];
        for (int i = 0; i < N; i++) {
            nodes[i] = new Node (i);
        }

        for (int i = 0; i < M; i++) {
            nodes[e[i].Item1 - 1].to.Add (e[i].Item2 - 1);
        }

        var pq = new PriorityQueue<Node> (N);

        int tmp = 1;
        foreach (var x in e.Select (v => v.Item2).OrderBy (v => v).ToList ().Distinct ()) {
            while (x != tmp) {
                pq.Push (nodes[tmp - 1]);
                tmp++;
            }
            tmp++;
        }

        while (pq.Count () > 0) {
            var node = pq.Pop ();
            Console.WriteLine ("pop {0} {1}", node.n, node.val);
            foreach (var next in node.to) {
                if (node.val + 1 > nodes[next].val) {
                    nodes[next].val = node.val + 1;
                    pq.Push (nodes[next]);
                    Console.WriteLine ("push {0} {1}", nodes[next].n, nodes[next].val);
                    for (var tmp2 = 0; tmp2 < pq.size; tmp2++) {
                        Console.Write ("{0} {1}  ", pq.heap[tmp2].n, pq.heap[tmp2].val);
                    }
                }
            }
        }
        Console.Out.Flush ();
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
}

class Node : IComparable<Node> {
    public int n;
    public int val;
    public List<int> to;
    public Node (int n) {
        this.val = 0;
        this.n = n;
        this.to = new List<int> ();
    }
    public int CompareTo (Node v) {
        return v.val - val;
    }
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