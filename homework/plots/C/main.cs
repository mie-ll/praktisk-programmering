using System;
using static System.Console;
using static System.Math;

class main{
	
	public static complex G(complex z){
		if(cmath.abs(z)<0) return PI/cmath.sin(PI*z)/G(1-z);
		if(cmath.abs(z)<9) return G(z+1)/x;
		complex lngamma = z*cmath.log(z+1/(12*z-1/z/10))-z+cmath.log(2*PI/z)/2;
		return cmath.exp(lngamma);
	}

	public static void Main(){
		for(double x = -4; x <= 4; x += 1.0/8){
			for(double y = -4; y <= 4; y += 1.0/8){
				\\.....
			}
		}
		
	}

}
