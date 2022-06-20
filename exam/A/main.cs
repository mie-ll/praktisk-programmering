using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(){
		//Start and end points:
		double begin = 0;
		double end = 10;		

		//Test of two step method:
		Func<double,vector,vector> f1 = delegate(double x, vector y){
			double theta = y[0];
			double omega = -y[1];
			return new vector(omega, theta);
		};
		
		vector y0_1 = new vector(0,-1);

		var xlist_11 = new genlist<double>();
		var ylist_11 = new genlist<vector>();
		(vector yend_11, int steps_11) = ode.driver_onestep(f1, begin, y0_1, end, xlist_11, ylist_11);
		for(int i=0; i<xlist_11.size; i++){
			WriteLine($"{xlist_11.data[i]} {ylist_11.data[i][0]} {ylist_11.data[i][1]} {-Cos(xlist_11.data[i])}");
		}
		
		WriteLine($"\n");
		
		var xlist_21 = new genlist<double>();
		var ylist_21 = new genlist<vector>();
		(vector yend_21, int steps_21) = ode.driver(f1, begin, y0_1, end, xlist_21, ylist_21);
		for(int i=0; i<xlist_21.size; i++){
			WriteLine($"{xlist_21.data[i]} {ylist_21.data[i][0]} {ylist_21.data[i][1]} {-Cos(xlist_21.data[i])}");
		}

		WriteLine($"\n");

		//Test of two step method, scipy exampel:
		double b = 0.25;
		double c = 5;
		Func<double,vector,vector> f2 = delegate(double x, vector y){
			double theta = y[0];
			double omega = y[1];
			return new vector(omega, -b*omega-c*Sin(theta));
		};
		
		vector y0 = new vector(PI-0.1,0.0);

		//One-step
		var xlist_1 = new genlist<double>();
		var ylist_1 = new genlist<vector>(); 
		(vector yend_1, int steps_12) = ode.driver_onestep(f2, begin, y0, end, xlist_1, ylist_1);
		for(int i=0; i<xlist_1.size; i++){
			WriteLine($"{xlist_1.data[i]} {ylist_1.data[i][0]} {ylist_1.data[i][1]}");
		}

		WriteLine($"\n");

		//Two-step
		var xlist_2 = new genlist<double>();
		var ylist_2 = new genlist<vector>();
		(vector yend_2, int steps_22) = ode.driver(f2, begin, y0, end, xlist_2, ylist_2);
		for(int i=0; i<xlist_2.size; i++){
			WriteLine($"{xlist_2.data[i]} {ylist_2.data[i][0]} {ylist_2.data[i][1]}");
		}
		
		WriteLine($"\n");

		//Test3: dy/dx=x^2y+y
		Func<double,vector,vector> f3 = delegate(double x, vector y){
			double theta = y[0];
			double omega = y[1];
			return new vector(omega, +b*omega+c*Cos(theta));
		};
		vector yn0 = new vector(PI-0.1,0.0);
		//One-step
		var xlist_13 = new genlist<double>();
		var ylist_13 = new genlist<vector>(); 
		(vector yend_13, int steps_13) = ode.driver_onestep(f3, begin, yn0, end, xlist_13, ylist_13);
		for(int i=0; i<xlist_13.size; i++){
			WriteLine($"{xlist_13.data[i]} {ylist_13.data[i][0]} {ylist_13.data[i][1]}");
		}
		
		WriteLine($"\n");
		//Two-step
		var xlist_23 = new genlist<double>();
		var ylist_23 = new genlist<vector>();
		(vector yend_23, int steps_23) = ode.driver(f3, begin, yn0, end, xlist_23, ylist_23);
		for(int i=0; i<xlist_23.size; i++){
			WriteLine($"{xlist_23.data[i]} {ylist_23.data[i][0]} {ylist_23.data[i][1]}");
		}
		


Error.WriteLine("Ordinary differential equations:");
Error.WriteLine("Here equations have been solved by using the new implemented two-step method. The first step is made by the one-step method knonw as Runge-Kutta(RK45).");
Error.WriteLine("Test have been mad to compare the two-step method with the one-step method.");
Error.WriteLine($"Test 1: y''=-y. Here the one-step method used {steps_11} iterations and the two-step method used {steps_21}.");
Error.WriteLine($"Test 2: y''+b*y'+c*sin(y)=0. Here the one-step method used {steps_12} iterations and the two-step method used {steps_22}.");
Error.WriteLine($"Test 3: y''-b*y'-c*cos(y)=0. Here the one-step method used {steps_13} iterations and the two-step method used {steps_23}.");
Error.WriteLine("See the figures(test1.pdf, test2.pdf and test3.pdf) for visuel comparison.");
	}//Main
}//main
