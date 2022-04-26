using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(){
		WriteLine("Testing of Newton's method with numerical Jacobian and back-tracking linesearch");

		WriteLine("\n");
		
		WriteLine("Test function f(x)=x^2");
		WriteLine("Finding the extremum of f(x) by searching for the roots of the gradient f'(x)=2x");
		Func<vector,vector> f1 = x => new vector(2*x[0]);
		vector x01 = new double[1] {0.5};
		vector result1 = roots.newton(f1, x01);
		WriteLine($"The extremum is found at");
		result1.print();
		WriteLine("and the analytical result is 0");
	
		WriteLine("\n");

		WriteLine("Test function f(x)=log(x)*x^2");
		WriteLine("Finding the extremum of f(x) by searching for the roots of the gradient f'(x)=x+2*x*log(x)");
		Func<vector,vector> f2 = x => new vector(2*x[0]*Log(x[0])+x[0]);
		vector x02 = new double[1] {0.5};
		vector result2 = roots.newton(f2, x02);
		WriteLine($"The extremum is found at");
		result2.print();
		WriteLine("and the analytical result is 0.6065");

		WriteLine("\n");
/*
Func<vector,vector> f2 = x => new vector(2*(200*Pow(x[0],3) - 200*x[0]*x[1] + x[0] - 1), 200*(x[1] - Pow(x[0],2)));
		vector x02 = new double[2] {0,0};
		vector res2 = roots.newton(f2, x02);
		WriteLine("\nFinding extremum of Rosenbrock's valley function f(x,y) = (1-x)^2 + 100(y-x^2)^2");
		WriteLine("This is done by searching for roots of its gradient f'(x,y) = [2*(200*x^3 - 200*x*y + x - 1), 200*(y - x^2)]");
		WriteLine("This extremum is found at:");
		WriteLine($"\tx = {res2[0]}, y = {res2[1]}");
		WriteLine("\tAnalytical result is (1,1)");
*/		
		WriteLine("Test function f(x,y)=(1-x)^2+100*(y-x^2)^2");
		WriteLine("Finding the extremum of f(x) by searching for the roots of the gradient f'(x,y)=(-2*(1-x)-400*x*(y-x^2), 200(y-x^2))");
		Func<vector,vector> f3 = x => new vector((-2*(1 - x[0]) -2*x[0]*200*(x[1] - x[0]*x[0])), (200*(x[1] - x[0]*x[0])));
		vector x03 = new double[2] {0.5, 0.5};
		vector result3 = roots.newton(f3, x03);
		WriteLine($"The extremum is found at");
		result3.print();
		WriteLine("and the analytical result is (1,1)");

	}//Main

}//calls

