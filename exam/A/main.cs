using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(){
//		WriteLine("Hello!");
		
		double b = 0.25;
		double c = 5;
		Func<double,vector,vector> f = delegate(double x, vector y){
			double theta = y[0];
			double omega = y[1];
			return new vector(omega, -b*omega-c*Sin(theta));
		};
		
		
		double begin = 0; //Start and end values for the function, so the plot will look like the one fromscipy
		double end = 10;
		vector y0 = new vector(PI-0.1,0.0);

		//One-step
		var xlist_1 = new genlist<double>();
		var ylist_1 = new genlist<vector>(); 
		vector yend_1 = ode.driver_onestep(f, begin, y0, end, xlist_1, ylist_1);
//WriteLine("h1");
		for(int i=0; i<xlist_1.size; i++){
			WriteLine($"{xlist_1.data[i]} {ylist_1.data[i][0]} {ylist_1.data[i][1]}");
		}
//WriteLine("h2");		
		WriteLine($"\n");
//WriteLine("h3"); 

		//Two-step
		var xlist_2 = new genlist<double>();
		var ylist_2 = new genlist<vector>();
		vector yend_2 = ode.driver(f, begin, y0, end, xlist_2, ylist_2);
//WriteLine("h4"); 		
		for(int i=0; i<xlist_2.size; i++){
			WriteLine($"{xlist_2.data[i]} {ylist_2.data[i][0]} {ylist_2.data[i][1]}");
		}
//	WriteLine("h5"); 			
	}//Main



}//main
