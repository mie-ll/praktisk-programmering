using System;
using static System.Math;

public static partial class lsfit{
	
	public static double[] fit(double[] xs, double[] ys, double[] dys, Func<double,double>[] funcs){
		int n = xs.Length;
		int m = funcs.Length;
		matrix A = new matrix(n,m);
		matrix Q = A.copy();
		matrix R = new matrix(m,m);
		vector b = new vector(n);
		for(int i=0; i<n; i++){ //Make matrix
			b[i] = ys[i]/dys[i];
			for(int j=0; j<m; j++){
				Q[i,j] = funcs[j](xs[i])/dys[i];
			}
		}
		//Decompose
		lineq.QRGSdecomp(Q,R);
		//Solving system
		vector c = lineq.QRGSsolve(Q,R,b);
		return c;
		
	}

}
