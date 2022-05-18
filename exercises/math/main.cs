using static System.Math;
public static class math {
	static void Main(){
		double sqrt2=Sqrt(2.0);
		System.Console.Write($"sqrt(2) = {sqrt2}, should be 1.41\n");
		System.Console.Write($"sqrt2*sqrt2 = {sqrt2*sqrt2}, , should be 2\n");
		
		double exppi=Exp(PI);
		System.Console.Write($"exp(pi) = {exppi}, should be 23.14\n");

		double pie=Pow(PI,E);
		System.Console.Write($"pi to the power of e = {pie}, should be 22.45\n");
	}

}
