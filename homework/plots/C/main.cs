using System;
using static System.Console;
using static System.Math;

class main{
	
	public static complex G(complex z){
		if(cmath.abs(z)<0) return PI/cmath.sin(PI*z)/G(1-z);
		if(cmath.abs(z)<9) return G(z+1)/z;
		complex lngamma = z*cmath.log(z+1/(12*z-1/z/10))-z+cmath.log(2*PI/z)/2;
		return cmath.exp(lngamma);
	}

	public static void Main(){
		for(double x = -5.1; x <= 5.1; x += 1.0/32){
			for(double y = -5.1; y <= 5.1; y += 1.0/32){
				complex z = new complex(x, y);
				complex gam = G(z);
				WriteLine($"{z.Re} {z.Im} {cmath.abs(gam)}");
			}
		}
		
	}

}
