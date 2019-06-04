using System;

class Program
{
  static void Main(string[] args)
  {
    string[] str = Console.ReadLine().Split(' ');
    int H = int.Parse(str[0]);
    //int W = int.Parse(str[1]);
    int A = int.Parse(str[2]);
    //int B = int.Parse(str[3]);
    
    int[][] HA = new int[H-A][2];

    for (int i=0; i<H-A; i++) {
      HA[i][0] = H-A;
      HA[i][1] = i;
      Console.Write(HA[i][0]);
      Console.Write(HA[i][1]);
    }
  }
}
