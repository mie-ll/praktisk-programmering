using System;
using static System.Console;
using static System.Random;

class main{
	public static void Main(){
		WriteLine($"A1:");
		//Testing lineq.cs method QRGSdecomp
		int n = 6, m = 4;
		matrix A = new matrix(n,m);
		var rand = new Random();
		for(int i=0; i<n; i++){
			for(int j=0; j<m; j++){
				A[i,j] = rand.NextDouble();
			}
		}
		matrix A_copy = A.copy();
		WriteLine($"Random generated {n} by {m} matrix:");
		A.print();
				
		WriteLine($"\n");

		WriteLine($"Factorizing matrix A into Q and R:");
		matrix R = new matrix(m,m);
		matrix Q = new matrix(n,m);
		Q = A.copy();
		lineq.QRGSdecomp(Q, R);
		WriteLine($"Q matrix after decomposition:");
		Q.print();
		WriteLine($"R matrix after decomposition:");
		R.print();
		
		WriteLine($"\n");
		
		WriteLine($"\nIt is upper triangular!");

		WriteLine($"\n");

		WriteLine($"Checking that Q^T*Q = 1:");
		matrix Q_trans_Q = Q.transpose()*Q;
		Q_trans_Q.print();
		
		WriteLine($"\n");

		WriteLine($"Checking that Q*R = A:");
		matrix QR = Q*R;
		QR.print();
		WriteLine($"QR is (approx) equal to A: {A_copy.approx(Q*R)} \n");
		
		WriteLine($"----------------------------");
		WriteLine($"\n");
		WriteLine($"A2:");
		//Testing lineq.cs method QRGSsolve
		int n2 = 8, m2 = n2;
		matrix A2 = new matrix(n2,m2);
		matrix R2 = new matrix(n2,m2);
		vector b = new vector(n2);
		for(int i=0; i<n2; i++){
			b[i] = rand.NextDouble();
			for(int j=0; j<m2; j++){
				A2[i,j] = rand.NextDouble();
			}
		}
				
		WriteLine($"Random generated {n} by {m} matrix, A:");
		A.print();
		WriteLine("$Randomly generated vector b:");
		b.print();
		
		WriteLine($"\n");

		WriteLine("$Factorizing A into QR:");
		matrix A2_0 = A2.copy();
		lineq.QRGSdecomp(A2, R2);
		A2.print();
		R2.print();

		WriteLine($"\n");

		WriteLine("$Solving the system of equations QPx=b. The solution (x) is:");
		matrix Q2 = A2.copy();
		vector x = lineq.QRGSsolve(Q2, R2, b);
		x.print();
		
		WriteLine("$Checking that A*x=b.");
		WriteLine("$A*x equals:");
		vector Ax = A2_0*x;
		Ax.print();
		WriteLine("$b equals:");
		b.print();
		WriteLine($"Is A*x approximately equal to b? {Ax.approx(b)}");
		
		WriteLine("$----------------------------");

	}

}
