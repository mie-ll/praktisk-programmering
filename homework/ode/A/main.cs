using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(){
		double b = 0.25;
		double c = 5;
		Func<double,vector,vector> f = delegate(double x, vector y){
			double theta = y[0];
			double omega = y[1];
			return new vector(omega, -b*omega-c*Sin(theta));
		};
		
		//RK45
		double begin = 0; //Start and end values for the function, so the plot will look like the one fromscipy
		double end = 10;
		vector y0 = new vector(PI-0.1,0.0);
		vector yend = ode.driver(f, begin, y0, end);
		
		Error.WriteLine($"\n");
		
		//Debug
		Func<double,vector,vector> f1 = delegate(double x, vector y){
			double theta = y[0];
			double omega = -y[1];
			return new vector(omega, theta);
		};
		vector y0_test = new vector(0,-1);
		vector yend_test = ode.driver(f1, begin, y0_test, end);


	}

}
