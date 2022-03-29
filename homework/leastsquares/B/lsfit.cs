using System;
using static System.Math;

public static partial class lsfit{
	
	public static (double[], matrix) fit(double[] xs, double[] ys, double[] dys, Func<double,double>[] funcs){
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
		
		double[] cs = new double[c.size];
		for(int i=0; i<cs.Length; i++){
			cs[i] = c[i];
		}
		
		//Covariance matrix S=(R^T*R)^-1
		matrix R_trans_R = R.transpose()*R;
		matrix R2 = new matrix(m,m);
		lineq.QRGSdecomp(R_trans_R,R2);
		matrix S = lineq.QRGSinverse(R_trans_R,R2);
		
		return (cs,S);
		
		
		
	}

}
