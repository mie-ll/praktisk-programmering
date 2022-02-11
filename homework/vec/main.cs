usin static 
public class vec{
	public double x=0, y=0, z=0;

	//constructors:
	public vec(double a, double b, double c){
		x=a; y=b; z=c;
		} 
	public vec(){x=y=z=0;}

	//print method 
	public void print(string s){
		Write(s); WriteLine($"{x} {y} {z}");
		}
	public void print(){this.print("");}
	public static void print(vec v){v.print("");}

	//operators:
	public static vec operator*(vec u, double c){ 
                return new vec(c*v.x, c*v.y, c*v.z);
                }

	public static vec operator*(double c, vec u){
                return u*c;
                }

	public static vec operator+(vec u, vec v){
		return new vec(u.x+v.x, u.y+v.y, u.z+v.z);
		}
	
	public static vec operator+(vec u){return u;}
	public static vec operator-(vec u){return -1*u;}
	
	public static vec operator-(vec u, vec v){
		return new vec(u.x-v.x,u. u.y-v.y, u.z-v.z);
		}


}
