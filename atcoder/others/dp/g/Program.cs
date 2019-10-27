﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

class Procon {
    static int[] DP;
    static List<int>[] edges;
    static void Main (string[] agrs) {
        var N = Int ();
        var M = Int ();

        DP = new int[N];
        edges = new List<int>[N];
        for (int i = 0; i < N; i++) {
            DP[i] = -1;
            edges[i] = new List<int> ();
        }

        for (int i = 0; i < M; i++) {
            edges[Int () - 1].Add (Int () - 1);
        }

        for (int i = 0; i < N; i++) {
            recur (i);
        }

        int ans = 0;
        for (int i = 0; i < N; i++) {
            ans = Math.Max (ans, DP[i]);
        }

        Console.WriteLine (ans);
    }

    static int recur (int i) {
        if (DP[i] != -1) {
            return DP[i];
        }

        int max = 0;
        for (int j = 0; j < edges[i].Count (); j++) {
            max = Math.Max (max, recur (edges[i][j]) + 1);
        }
        DP[i] = max;
        return max;
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

class PriorityQueue<T> where T : IComparable<T> {
    public T[] heap;
    public int size;
    public int sign;
    public PriorityQueue (int N, bool descend = false) {
        heap = new T[N];
        sign = 1;
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