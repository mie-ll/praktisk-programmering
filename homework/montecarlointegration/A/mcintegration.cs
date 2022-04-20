using System;
using static System.Console;
using static System.Math;

public class mcintegration{

	public static (double, double) plainmc(Func<vector, double> f, vector a, vector b, int N){
		int dim = a.size;
		double V = 1;
		for(int i=0; i<dim; i++){
			V *= b[i]-a[i];
		}
		double  sum = 0, sum2 = 0;
		var x = new vector(dim);
		for(int i=0; i<N;  i++){
			double fx = f(x);
			sum += fx;
			sum2 += fx*fx;
		}
		double mean = sum/N;
		double sigma = Sqrt(sum2/N-mean*mean);
		var result = (mean*V, sigma*V/Sqrt(N));
		return result;
	}//plainmc

}//class
