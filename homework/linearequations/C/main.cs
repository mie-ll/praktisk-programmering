using System;
using static System.Console;
using static System.Random;
using System.Diagnostics;

public class main{
	public static void Main(){
		//Making random matrix:
		var rand = new Random();
		int N = 400;
		for(int n=10; n<=N; n+=10){
			matrix A = new matrix(n,n);
			matrix R = new matrix(n,n);
			for(int i=0; i<n; i++){
				for(int j=0; j<n; j++){
					A[i,j] = rand.NextDouble();
				}
			}
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			lineq.QRGSdecomp(A,R);
			stopwatch.Stop();
			double time = stopwatch.ElapsedMilliseconds;
			WriteLine($"{n} {time}");
		}
	
	}

}
