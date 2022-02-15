using static System.Console;
using static System.Math;

public class main{
	static void Main(){
		
		Write("Exercise 1:\n");

		int i=1;
		while(i+1>i) {i++;}
		Write("my max int = {0}\n",i);
		Write($"System max int = {int.MaxValue} \n");		
		
		int j=1;
		while(j-1<i) {j++;}
		Write("my min int = {0}\n",j);
		Write("System min int = {0}\n", int.MinValue);
	

		Write("Exercise 2:\n");

		double x=1;
		while(1+x!=1){x/=2;}
		x*=2;
		Write($"The machine epsilon for double = {x}\n");
		
		float y=1F;
		while((float)(1F+y) != 1F){y/=2F;} 
		y*=2F;
		Write($"The machine epsilon for float = {y}\n");


		Write("Exercise 3:\n");

		int n=(int)1e6;
		double epsilon=Pow(2,-52);
		double tiny=epsilon/2;
		double sumA=0,sumB=0;

		sumA+=1;
		for(int k=0;k<n;k++){sumA+=tiny;}
		WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");

		for(int h=0;h<n;h++){sumB+=tiny;}
		sumB+=1;
		WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");


		Write("Exercise 4:\n");
		double a = 2e-9;
		double b = 1.5e-9;
		Write($"a = {a}, b = {b} and |a-b|<1e-9 should be True and it is {approx(a,b)}\n");

	}


	public static bool approx(double a, double b, double tau=1e-9, double epsilon=1e-9){
		if (Abs(a-b)<tau) {return true;}
		if (Abs(a-b)/(Abs(a) + Abs(b)) < epsilon) {return true;}
		else {return false;}

	}




}

