using System;
using System.Collections.Generic;

class Program
{
  static void Main(string[] args)
  {
    string[] str = Console.ReadLine().Split(' ');
    int N = int.Parse(str[0]);
    int M = int.Parse(str[1]);
    int R = int.Parse(str[2]);

    
    int[] r = new int[R];
    string[] R_str = Console.ReadLine().Split(' ');
    for (int i=0; i<R; i++) {
      r[i] = int.Parse(R_str[i]);
    }

    int[,] x = new int[N, N];
    for (int i=0; i<N; i++) {
      for (int j=0; j<N; j++) {
        if ( i==j ) {
          x[i,j] = 0;
        } else {
          x[i,j] = 1000;
        }
      }
    }

    for (int i=0; i<M; i++) {
      string[] tmp = Console.ReadLine().Split(' ');
      int a = int.Parse(tmp[0]) -1 ;
      int b = int.Parse(tmp[1]) -1;
      int c = int.Parse(tmp[2]);
      x[a, b] = c;
      x[b, a] = c;
    }

    for (int k=0; k<N; k++) {
      for (int i=0; i<N; i++) {
        for (int j=0; j<N; j++) {
          x[i, j] = Math.Min(x[i,j], x[i, k] + x[k, j]);
        }
      }
    }

    int max = factorical(R);
    int min = 10000;

    for (int i=0; i<max; i++) {
      int[] c = combination(R, i, r);
      int tmp = 0;
      for (int j=1; j<R; j++) {
        tmp += x[c[j-1]-1, c[j]-1];
      }
      min = Math.Min(min, tmp);
    }

    Console.WriteLine(min);
  }

  static int factorical(int i) {
    if (i > 0) {
      return i * factorical(i-1);
    }
    return 1;
  }

  // 遅くて通らない
  static int[] combination(int r, int n, int[] list) {
    List<int> c = new List<int>();
    for (int i=0; i<r; i++) {
      c.Add(i);
    }
      
    int[] ret = new int[r];
    int tmp_r = r;
    for (int i=0; i<r; i++) {
      ret[i] = list[c[n%tmp_r]];
      c.RemoveAt(n%tmp_r);
      n /= tmp_r;
      tmp_r -= 1;
    }
    return ret;
  }
}


