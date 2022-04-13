using System;
using static System.Console;
using static System.Math;
using static System.Double;

public class main{
	public static void Main(){
		WriteLine($"Test of integration:");
		
		int i = 0, j = 0, k = 0, l = 0;
		
		Func<double,double> f1 = x => {i++; return Exp(-x*x);};
		double result1 = integration.integrate(f1, NegativeInfinity, PositiveInfinity);
		WriteLine($"Integration of expt-(x^2) from -infinite to +infinite = {result1} - number of evaluations: {i}");
	
		Func<double,double> f2 = x => {j++; return 1.0/(1+x*x);};
		double result2 = integration.integrate(f2, NegativeInfinity, 0);
		WriteLine($"Integration of 1/(1+x^2) from -infinite to 0 = {result2}  - number of evaluations: {j}");
		
		Func<double,double> f3 = x =>{k++; return 1.0/(x*x);};
		double result3 = integration.integrate(f3, 1, PositiveInfinity);
		WriteLine($"Integration of 1/x^2 from 1 to +infinite = {result3}  - number of evaluations: {k}");

		Func<double,double> f4 = x => {l++; return Log(x)/Sqrt(x);};
		double result4 = integration.integrate(f4, 0, 1);
		WriteLine($"Integration of ln(x)/sqrt(x) from 0 to 1 = {result4}  - number of evaluations: {l}");

		WriteLine($"Python scipy comparison:");
		var instream =new System.IO.StreamReader("python_result.txt");
		for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
        	WriteLine(line);
		}
	
	}//Main

}//class
