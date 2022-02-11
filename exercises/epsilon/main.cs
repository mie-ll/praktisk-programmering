using static System.Console;
using static System.Math;

public static class main{
	static void Main(){
		maxint();
		minint();
	}	
	
	static void maxint(){
		int i=1;
		while(i+1>i) {i++;}
		
		Write("my max int = {0}\n",i);
		Write($"System max int = {int.MaxValue} \n");		
		}

	static void minint(){
		int i=1;
		while(i-1<i) {i++;}
		
		Write("my min int = {0}\n",i);
		Write("System min int = {0}\n", int.MinValue);
		}






}
