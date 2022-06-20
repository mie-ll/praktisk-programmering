using System;
using static System.Console;
using static System.Math;

public class ode{
	//One-step stepper: Runge-Kutta-Fehlberg(RKF45):	
	public static (vector,vector) rkstep45(Func<double,vector,vector> f, double x, vector y, double h){
		//Constants - see Butcher table from capther ode.
		double c1 = 0;
		double c2 = 1.0/4;
		double c3 = 3.0/8;
		double c4 = 12.0/13;
		double c5 = 1.0;
		double c6 = 1.0/2;

		double a21 = 1.0/4;
		double a31 = 3.0/32;
		double a41 = 1932.0/2197;
		double a51 = 439.0/216;
		double a61 = -8.0/27;
		double a32 = 9.0/32;
		double a42 = -7200.0/2197;
		double a52 = -8.0;
		double a62 = 2.0;
		double a43 = 7296.0/2197;
		double a53 = 3680.0/513;
		double a63 = -3544.0/2565;
		double a54 = -845.0/4104;
		double a64 = 1859.0/4104;
		double a65 = -11.0/40;
		
		double b1 = 16.0/135;
		double b2 = 0.0;
		double b3 = 6656.0/12825;
		double b4 = 28561.0/56430;
		double b5 = -9.0/50;
		double b6 = 2.0/55;

		double b1s = 25.0/216;
		double b2s = 0.0;
		double b3s = 1408.08/2565;
		double b4s = 2197.0/4104;
		double b5s = -1.0/5;
		double b6s = 0.0;
	
		//Runge-Kutta equation 19:
		vector K1 = h*f(x, y);
		vector K2 = h*f(x+c2*h, y+a21*K1);
		vector K3 = h*f(x+c3*h, y+a31*K1+a32*K2);
		vector K4 = h*f(x+c4*h, y+a41*K1+a42*K2+a43*K3);
		vector K5 = h*f(x+c5*h, y+a51*K1+a52*K2+a53*K3+a54*K4);
		vector K6 = h*f(x+c6*h, y+a61*K1+a62*K2+a63*K3+a64*K4+a65*K5);
		//y_(n+1) = y_n+sum(b_i*k_i):
		vector yh = y + b1*K1 + b2*K2 + b3*K3 + b4*K4 + b5*K5 +b6*K6; //eq 18
		//y_(n+1)^* = y_n+sum(b_i^* *k_i):
		vector yhs = y + b1s*K1 + b2s*K2 + b3s*K3 + b4s*K4 + b5s*K5 +b6s*K6; //eq 22
		//e_n=y_(n+1)-y_(n+1)^*:
		vector er = yh-yhs; // eq 23

		return (yh, er);
	}//rkstep45

	//two-step method:
	public static (vector,vector) twostep(Func<double,vector,vector> f, double xn, vector yn, double h, double x_previous, vector y_previous){
		vector Y_n = f(xn,yn); //y_n'=f(x_n, y_n)
		vector y_n_1 = y_previous; //y_(n-1) is know, the previous point
		double dx = xn-x_previous; //the difference between the previous point and the current point
		vector c = (y_n_1-yn+Y_n*dx)/(dx*dx); // eq. 33
		//The next point
		vector y_np1 = yn+Y_n*h+c*(h*h); //y_(n+1)=y_n+y_n'*h+c*h*h eq. 32
		vector yh = y_np1;
		//Error estimate
		vector er = c*(h*h);

		return (yh, er);
	} //twostep


	//Driver two-step
	public static (vector,int) driver(
		Func<double,vector,vector> f,
		double a, vector ya, double b,
		genlist<double> xlist=null, genlist<vector> ylist=null,
		double h=0.01, double acc=1e-2, double eps=1e-2){

		if(a>b){throw new Exception("driver: a>b");}
		double x = a;
		vector y = ya;
		vector y_pre = ya;
		double x_pre = a;
		int steps = 0;
		if(xlist != null && ylist != null){
			xlist.push(x);
			ylist.push(ya);
		}
		//Findes the first point with one-step method:
			if(x>=b){return (y,steps);}
			if(x+h>b){h=b-x;}
		 (vector yh,vector erv) = rkstep45(f,x,y,h); //One-step method
			vector tol = new vector(erv.size);
			bool ok = true;
			for(int i=0; i<tol.size; i++){
				tol[i] = Max(acc, Abs(yh[i])*eps)*Sqrt(h/(b-a));
				ok = ok && erv[i]<tol[i];} //boolsk udtryk &&
			if(ok){
				x_pre = x;
				x += h;
				y_pre = y;			
				y = yh;
				if(xlist != null && ylist != null){
					xlist.push(x); ylist.push(y); steps++;} }
			double factor = tol[0]/Abs(erv[0]);
			for(int i=1; i<tol.size; i++){ factor = Min(factor, tol[i]/Abs(erv[i])); }
			h *= Min(Pow(factor,0.25)*0.95, 2);
		//Findes the last steps with two-step method:
		do{
			if(x>=b){return (y,steps);}
			if(x+h>b){h=b-x;}
		(yh,erv) = twostep(f,x,y,h, x_pre ,y_pre); //Two-step method		
			ok = true;
			for(int i=0; i<tol.size; i++){
				tol[i] = Max(acc, Abs(yh[i])*eps)*Sqrt(h/(b-a));
				ok = ok && erv[i]<tol[i]; }
			if(ok){
				x_pre = x;
				x += h;
				y_pre = y;
				y = yh;
				if(xlist != null && ylist != null){					
					xlist.push(x); ylist.push(y); steps++; } }
			factor = tol[0]/Abs(erv[0]);
			for(int i=1; i<tol.size; i++){ factor = Min(factor, tol[i]/Abs(erv[i])); }
			h *= Min(Pow(factor,0.25)*0.95, 2);	
		}while(true);		
	}//driver


	public static (vector, int) driver_onestep(
		Func<double,vector,vector> f,
		double a, vector ya, double b,
		genlist<double> xlist=null, genlist<vector> ylist=null,
		double h=0.01, double acc=1e-5, double eps=1e-5){

		int steps = 1; //Number of iterations
		if(a>b){throw new Exception("driver: a>b");}
		double x = a;
		vector y = ya;
		if(xlist != null && ylist != null){ xlist.push(x); ylist.push(ya);}
		do{
			if(x>=b){return (y, steps);}
			if(x+h>b){h=b-x;}
			var (yh,erv) = rkstep45(f,x,y,h); //One-step method
			vector tol = new vector(erv.size);
			bool ok = true;
			for(int i=0; i<tol.size; i++){
				tol[i] = Max(acc, Abs(yh[i])*eps)*Sqrt(h/(b-a));
				ok = ok && erv[i]<tol[i]; }
			if(ok){
				x += h;	y = yh;
				if(xlist != null && ylist != null){
					xlist.push(x);
					ylist.push(y);
					steps++; } }
			double factor = tol[0]/Abs(erv[0]);
			for(int i=1; i<tol.size; i++){ factor = Min(factor, tol[i]/Abs(erv[i])); }
			h *= Min(Pow(factor,0.25)*0.95, 2);
		}while(true);
	}//driver

}//class

