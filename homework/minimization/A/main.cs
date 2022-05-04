using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(){
		
		WriteLine("Test function f(x,y)=(1-x)^2+100*(y-x^2)^2");
		WriteLine("Finding the minimum of the function");
		Func<vector,double> f1 = x => (1 - x[0])*(1 - x[0]) + 100*(x[1] - x[0]*x[0])*(x[1] - x[0]*x[0]);
		vector x01 = new double[2] {0, 0};
		double acc1 = 1e-5;
		(vector, int) (result1,steps1) = mini.qnewton(f1, x01, acc: acc1);
		WriteLine($"Start guess ({x01[0]},{x01[1]})");
		WriteLine($"The minimum was found at ({result1[0]},{result1[1]}) in {steps1} steps.");
		WriteLine($"Here f(x,y) = {f1(result1)}");
		WriteLine("There is one minimum at (1,1), for f(x,y)=0");



	}//Main



}//class
