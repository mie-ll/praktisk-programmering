using System;
using static System.Console;
using static System.Math;
using static vec;
class main{
	static void Main(){
		
		WriteLine("part a");
		vec u=new vec(100,200,300);
		u.print("u=");
		vec v=new vec(1,2,3);
		v.print("v=");
		(u+v).print("u+v = ");
		(5*v).print("5*v=");
		var tmp=u*5;
		tmp.print("u*5 = ");
		var w=3*u-v;	
		w.print("w=");
		vec.print(w);
		WriteLine("Part c");
		WriteLine($"approximation of w and 3*u-v : {vec.approx(w,3*u-v)}");
		WriteLine($"approximation of w and 3*u-v : {w.approx(3*u-v)}");
		WriteLine($"approximation of u and v : {u.approx(v)}");
		WriteLine("part b");
		double dotted = dot(u,v);
		WriteLine($"Dot product of u and v={dotted}");
		WriteLine($"Cross Product of u and v: {cross(u,v)}");
		WriteLine($"Norm of u: {norm(u)}");

		WriteLine(v.ToString());
	}

}
