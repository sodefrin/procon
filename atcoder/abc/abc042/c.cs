using System;
using System.Collections.Generic;

class Program
{
  static void Main(string[] args)
  {
    string[] l1 = Console.ReadLine().Split(' ');
    int n = int.Parse(l1[0]);
    int k = int.Parse(l1[1]);

    int[] d = new int[k];
    string[] l2 = Console.ReadLine().Split(' ');
    for (int i=0; i<k; i++) {
      d[i] = int.Parse(l2[i]);
    }

    for (int i=n; ; i++) {
      bool ok = true;
      var ret = ParseInt(i);
      for (int j=0; j<ret.Count; j++) {
        for (int l=0; l<k; l++) {
          if (ret[j] == d[l]) {
            ok = false;
            break;
          }
        }
        if (ok == false) {
          break;
        }
      }

      if (ok == true) {
        Console.Write(i + "\n");
        return;
      }
    }
  }

  static List<int> ParseInt(int i) {
    var ret = new List<int>();
    for (; i>=10; i/=10) {
      ret.Add(i%10);
    }
    ret.Add(i);
    return ret;
  }
}
