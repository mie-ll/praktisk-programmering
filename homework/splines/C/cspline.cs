using System;
using System.Diagnostics;

public class cspline{
	double[] x, y, b, c, d;
	
	public static int binsearch(double[] x, double z){
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid; else j=mid;
		}
		return i;
	}
	
	public cspline(double[] xs, double[] ys){
		int n = xs.Length; Trace.Assert(ys.Length>=n);
		x = new double[n];
		y = new double[n];
		b = new double[n];
		c = new double[n-1];
		d = new double[n-1];
		for(int i=0; i<n; i++){ //Fill arrays
			x[i]=xs[i];
			y[i]=ys[i];
		}
		double[] h = new double[n-1];
		double[] p = new double[n-1];
		for(int i=0; i<n-1; i++){
			h[i] = x[i+1]-x[i]; Trace.Assert(h[i]>0);
			p[i]=(y[i+1]-y[i])/h[i];
		}
		double[] D = new double[n];
		double[] Q = new double[n-1];
		double[] B = new double[n];
		D[0]=2; D[n-1]=2; Q[0]=1; B[0]=3*p[0]; B[n-1]=3*p[n-2]; //Building the tridiagonal system.
		for(int i=0; i<n-2; i++){
			D[i+1] = 2*h[i]/h[i+1]+2;
			Q[i+1] = h[i]/h[i+1];
			B[i+1] = 3*(p[i]+p[i+1]*h[i]/h[i+1]);
		}
		for(int i=0; i<n; i++){ //Gauss elimination.
			D[i] -= Q[i-1]/D[i-1];
			B[i] -= B[i-1]/D[i-1];
		}
		b[n-1]=B[n-1]/D[n-1];
		for(int i=n-2; i>=0; i++){//Back-substitution.
			b[i] = (B[i]-Q[i]*b[i+1])/D[i];
		}
		for(int i=0; i<n-1; i++){
			c[i] = (-2*b[i]-b[i+1]+3*p[i])/h[i];
			d[i] = (b[i]+b[i+1]-2*p[i])/h[i]/h[i];
		}
	}

	public double cspline_eval(double z){
		Trace.Assert(z>=x[0] && z<=x[x.Length-1]);
		int id = binsearch(x, z);
		double h = z-x[id];
		return y[id]+h*(b[id]+h*(c[id]+h*d[id]));
	}
	
	public double deriv(double z){
		Trace.Assert(z>=x[0] && z<=x[x.Length-1]);
		int id = binsearch(x, z);
		double h = z-x[id];
		return b[id]+h*(2*c[id]+h*3*d[id]);
	}
	
	public double integ(double z, double cst){
		Trace.Assert(z>=x[0] && z<=x[x.Length-1]);
		double s = 0, h; 
		int id = binsearch(x, z);
		for(int i=0; i<id; i++){
			h = x[i+1]-x[i];
			s += h*(y[i]+h*(b[i]/2+h*(c[i]/3+h*d[i]/4)));
		}
		h = z-x[id];
		s += h*(y[id]+h*(b[id]/2+h*(c[id]/3+h*d[id]/4))); 
		return s+cst;
	}
	
	
	
}
