using System;
using static System.Console;
using static System.Math;

static class cmdline{
	public static void Main(string[] args){
		WriteLine("Part B");
		foreach(var arg in args){
			double x = double.Parse(arg);
			WriteLine($"{x} {Sin(x)} {Cos(x)}");
		}
	}

}
