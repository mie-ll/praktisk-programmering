using System;
using static System.Console;
using static System.Math;

class main{
	static void Main(){
		
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
		WriteLine(vec.approx(w,3*u-v));
		WriteLine(w.approx(3*u-v));
		WriteLine(u.approx(v));
//		dotted = dot(u,v);
//		WriteLine("Dot product of u and u={dotted}");
	}

}
