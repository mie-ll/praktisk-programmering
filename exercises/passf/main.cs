using System;
using static System.Console;
using static System.Math;
using static passf;

public static class main{
	public static void Main(){
		for(int i=1; i<=3; i++){
			passf.make_table(x=>Sin(i*x), 0, 2*PI, (double)PI/4);
		}
	}


}
