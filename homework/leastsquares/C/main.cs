using System;
using static System.Console;
using static System.Math;

public class main{

	public static void Main(){
		//Data:
		double[] xs = new double[] {1,  2,  3, 4, 6, 9,   10,  13,  15};
		double[] ys = new double[] {117,100,88,72,53,29.5,25.2,15.2,11.1};
		double[] dys = new double[] {5,5,5,5,5,1,1,1,1};
		//Fit function(canstant and linear term):
		var funcs = new Func<double,double>[] { z => 1.0, z => z};
		
		for(int i=0; i<xs.Length; i++){ //Data writen to a list
			WriteLine($"{xs[i]} {ys[i]} {dys[i]}");
		}
		
		WriteLine($"\n");
		
		for(int i=0; i<ys.Length; i++){ //Adjusting data for fit
			dys[i] = dys[i]/ys[i];
			ys[i] = Log(ys[i]);
		}
		
		//Fitting:
		(double[] cs, matrix S) = lsfit.fit(xs, ys, dys, funcs);
		
		for(double t=0; t<16; t+=1.0/32){ //Makes function from cs
			double res = 0;
			double res_p = 0;
			double res_m = 0;
			for(int j=0; j<funcs.Length; j++){
				double unc = Sqrt(S[j,j]);
				res += cs[j]*funcs[j](t);
				res_p += (cs[j]+unc)*funcs[j](t);
				res_m += (cs[j]-unc)*funcs[j](t);	
			}
			WriteLine($"{t} {Exp(res)} {Exp(res_p)} {Exp(res_m)}"); //exp since the fit is made in linear form
		}
		
	}


}
