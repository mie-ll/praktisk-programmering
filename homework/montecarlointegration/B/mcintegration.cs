using System;
using static System.Console;
using static System.Math;

public class mcintegration{

	public static (double, double) plainmc(Func<vector, double> f, vector a, vector b, int N){
		var rand = new Random();
		int dim = a.size;
		double V = 1.0;
		for(int i=0; i<dim; i++){
			V *= b[i]-a[i];
		}
		double  sum = 0, sum2 = 0;
		var x = new vector(dim);
		for(int i=0; i<N;  i++){
			for(int k=0; k<dim; k++){
				x[k] = a[k]+rand.NextDouble()*(b[k]-a[k]);
			}
			double fx = f(x);
			sum += fx;
			sum2 += fx*fx;
		}
		double mean = sum/N;
		double sigma = Sqrt(sum2/N-mean*mean); //variance eq 4
		double error = sigma*V/Sqrt(N); // eq 3
		var result = (mean*V, error); 
		return result;
	}//plainmc


	public static double corput(int n, int Base){
		double q = 0, bk = 1.0/Base;
		while(n>0){
			q += (n % Base)*bk;
			n /= Base;
			bk /= Base;
		}
		return q;
	}
	
	public static double[] halton(int n, int d, int sec=0){
		int[] Base = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67};
		if(d>Base.Length){
			throw new System.Exception("Halton method does not work - dimension is too large");
		} 
		double[] x = new double[d];
		for(int i=0; i<d; i++){
			x[i] = corput(n, Base[(i+sec)%Base.Length]);
		}
		return x;
	}

	public static (double, double) haltonmc(Func<vector,double> f, vector a, vector b, int N){
		int dim = a.size;
		double V = 1.0;
		for(int i=0; i<dim; i++){
			V *= b[i]-a[i];
		}
		double  sum = 0, sum2 = 0;
		double[] x = new double[dim];
		double[] x2 = new double[dim];
		int offset = 0;
		for(int i=0; i<N; i++){
			double[] quasi_rand = halton(i+offset, dim);
			double[] quasi_rand2 = halton(i+offset, dim, 4);
			for(int k=0; k<N; k++){
				x[k] = a[k] + quasi_rand[k]*(b[k]-a[k]);
				x2[k] = a[k] + quasi_rand2[k]*(b[k]-a[k]);
			}
			double fx = f(x);
			double fx2 = f(x2);
			if(double.IsNaN(fx) || double.IsInfinity(fx) || double.IsNaN(fx2) || double.IsInfinity(fx2)){
				--i; ++offset;
			} else {
				sum += fx;
				sum2 += fx2;
			}
		}
		double mean = sum/N;
		double mean2 = sum2/N;
		double sigma = Abs(mean*V-mean2*V);
		var result = (mean*V, sigma);
		return result;
		
		
	}








}//class
