using System;
using static System.Console;
using static System.Math;

public class roots{
	public static vector newton(Func<vector,vector> f, vector x0, double epsilon=1e-2){
		vector x = x0.copy();
		int n = x.size;
		matrix J = new matrix(n,n); //calculating the Jacobian matrix J
		double delta = 0;
		vector fy = new vector(n);
		vector y = new vector(n);
		vector fx = new vector(n);

		bool run1 = true;
		while(run1){
			fx = f(x);
			for(int i=0; i<n; i++){
				delta = Abs(x[i])*Pow(2,-23);
				x[i] += delta;
				for(int j=0; j<n; j++){
					J[i,j] = (f(x)[i]-fx[i])/delta;
				}
				x[i] -= delta;
			}
		matrix R = new matrix(n,n);
		matrix Q = J.copy();
		lineq.QRGSdecomp(Q,R);
		vector Dx = lineq.QRGSsolve(Q,R,-fx); // solving JDx=-fx, newtons step
		
		double lambda = 2.0;

		bool run2 = true; //While(||f(x+lambda*Dx)|| < (1-lambda/2)*||f(x)|| )
		while(run2){
			lambda /= 2; //λ←λ/2
			y = x+lambda*Dx; //x ← x + λ∆x
			fy = f(y);
			if(fy.norm() < (1-lambda/2.0)*fx.norm() || lambda < 1.0/64){
				run2 = false;
			}
		}//run2
		
		x = y;
		fx = fy;
		if(Dx.norm() < delta || fx.norm() < epsilon){
			run1 = false;
		}
		}//run1
		
		return x;
		
	}//newton

}//class
