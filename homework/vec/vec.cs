using static System.Console;
using static System.Math;
public class vec{
        public double x=0, y=0, z=0;
        //Constructors:
        public vec(double a, double b, double c){
                x=a; y=b; z=c;
                }
        public vec(){x=y=z=0;}

        //Print method:
        public void print(string s){
                Write(s); WriteLine($"{x} {y} {z}");
                }
        public void print(){this.print("");}
        public static void print(vec v){v.print("");}

        //Operators(+, -, *):
        public static vec operator*(vec u, double c){
                return new vec(c*u.x, c*u.y, c*u.z);
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
                return new vec(u.x-v.x, u.y-v.y, u.z-v.z);
                }


	//Dot product:
	public static double dot(vec u, vec v){
		return (u.x*v.x+u.y*v.y+u.z*v.z);
		}

	//Cross Product:
	public static vec cross(vec u, vec v){
		return new vec(u.y*v.z-u.z*v.y, u.x*v.z-u.z*v.x, u.x*v.y-u.y*v.x);
		}

	//Norm:
	public static double norm(vec u){
		double norm = (Sqrt(Pow(u.x,2)+Pow(u.y,2)+Pow(u.z,2)));
		return norm;
		}

	//Approx method: 
	static bool approx(double a, double b, double tau=1e-9, double eps=1e-9){
        	if(Abs(a-b) < tau) return true;
        	if(Abs(a-b)/(Abs(a)+Abs(b)) < eps) return true;
        	return false;
        	}

	public bool approx(vec other){
	        if(!approx(this.x,other.x)) return false;
	        if(!approx(this.y,other.y)) return false;
	        if(!approx(this.z,other.z)) return false;
	        return true;
	        }

	public static bool approx(vec u, vec v){ return u.approx(v); }

	//Override ToString method:
	public override string ToString(){
		return $"vec:({x} {y} {z})";
		}


}
