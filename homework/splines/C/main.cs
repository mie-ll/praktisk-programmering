using System;
using static System.Console;
using static System.Math;
using static cspline;

public class main{
	public static void Main(){
		//Tabulated values to test cspline after.
		double[] xs = new double[] {-5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5};
		double[] y1 = new double[xs.Length];
		for(int i=0; i<xs.Length; i++){ //Findes the y-values.
			y1[i] = xs[i]*xs[i];
		}
		for(int i=0; i<xs.Length; i++){ //Writes the tabulatede vaules in a tabel.
			WriteLine($"{xs[i]} {y1[i]}");
		}
		
		cspline s1 = new cspline(xs, y1);
		WriteLine($"1");		
		WriteLine($"\n");
		for(double z=-5; z<=5; z+=1.0/16){
			double inter = s1.cspline_eval(z);
			WriteLine($"2");
			double integ = s1.integ(z,-30);
			WriteLine($"3");
			double deriv = s1.deriv(z);
			WriteLine($"{z} {inter} {integ} {deriv}");
		}

	}






}
