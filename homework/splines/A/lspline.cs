
public class lspline{
	private double[] x,y;
	
	//Location of the index i of the interval containing z, x[i]<z<x[i+1] - using binary search.
	public static int binsearch(double[] x, double z){/* locates the interval for z by bisection */ 
		//if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid; else j=mid;
		}
		return i;
	}
	
	//Linear interploation from a table {x[i], y[i]} at a given point z.
	public double linterp(double z){
        	int id=binsearch(x,z);
        	//double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
        	double dy=y[id+1]-y[id];
		double dx=x[id+1]-x[id];
        	return y[id]+dy/dx*(z-x[id]);
        }
	
	public lspline(double[] xs, double[] ys){
		x=xs;
		y=ys;
	}
	
	//Calculates the intergral of the linear spline from the point x[0] to the given point z. 
	public double linterpInteg(double z, double cst){ //cst=constant
		double s = 0; //sum
		int id = binsearch(x, z);
		for(int i=0; i<id; i++){
			double p = (y[i+1]-y[i])/(x[i+1]-x[i]); //slope
			s += y[i]*(x[i+1] - x[i]) + p*(x[i+1] - x[i])*(x[i+1] - x[i]) / 2;
		}
		double pa = (y[id+1]-y[id])/(x[id+1]-x[id]);
		s += y[id]*(z - x[id]) + pa*(z - x[id])*(z - x[id]) / 2 + cst;
		return s;
	}
	
	
}


