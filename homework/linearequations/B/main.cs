using System;
using static System.Console;
using static System.Random;

public class main{
	public static void Main(){
		//Testing lineq.cs QRGSinverse
		int n = 2, m = 2;
		matrix A = new matrix(n,m);
		var rand = new Random();
		for(int i=0; i<n; i++){
			for(int j=0; j<m; j++){
				A[i,j] = rand.Next(11);
			}
		}
		matrix A_copy = A.copy();
		WriteLine($"Random generated {n} by {m} matrix:");
		A_copy.print();	

		WriteLine($"\n");

		WriteLine($"Factorize A into Q and R:");
		matrix R = new matrix(m,m);
		matrix Q = new matrix(n,m);
		lineq.QRGSdecomp(A,R);
		Q = A.copy();
		WriteLine($"Q matrix after decomposition:");
		Q.print();
		WriteLine($"R matrix after decomposition:");
		R.print();

		WriteLine($"\n");
		
		WriteLine($"The invers matrix A^-1:");
		matrix A_inv = lineq.QRGSinverse(Q,R);
		A_inv.print();
		
		WriteLine($"\n");

		WriteLine($"Checking A*A^-1=I:");
		matrix A_A_inv = A_copy*A_inv;
		A_A_inv.print();
		matrix I = new matrix(n,m);
		I.set_identity();
		WriteLine($"A*A^-1 is approximately equal to I: {A_A_inv.approx(I)}");
	}






}
