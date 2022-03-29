using System;
using static System.Math;

public class evd{

	public static void timesJ(matrix A, int p, int q, double theta){
		double c = Cos(theta);
		double s = Sin(theta);
		for(int i=0; i<A.size1; i++){
			double aip = A[i,p];
			double aiq = A[i,q];
			A[i,p] = c*aip-s*aiq;
			A[i,q] = s*aip+c*aiq;
		}
	}
	
	public static void Jtimes(matrix A, int p, int q, double theta){
		double c = Cos(theta);
		double s = Sin(theta);
		for(int j=0; j<A.size1; j++){
			double apj = A[p,j];
			double aqj = A[q,j];      
			A[p,j] = c*apj+s*aqj;
			A[q,j] = -s*apj+c*aqj;
		}
	}

	public static int JacobCyclic(matrix A, matrix V){
		int sweeps = 0; 
		int n = A.size1;
		V.set_unity();
		bool changed;
		do{
			sweeps++;
			changed = false;
			for(int p=0; p<n-1; p++){
				for(int q=p+1; q<n; q++){
					double apq=matrix.get(A,p,q);
					double app=matrix.get(A,p,p);
					double aqq=matrix.get(A,q,q);
					double theta=0.5*atan2(2*apq,aqq-app);
					double c=cos(theta),s=sin(theta);
					double new_app=c*c*app-2*s*c*apq+s*s*aqq;
					double new_aqq=s*s*app+2*s*c*apq+c*c*aqq;
					if(new_app!=app || new_aqq!=aqq){ // do rotation
						changed=true;
						timesJ(A,p,q, theta);
						Jtimes(A,p,q,-theta); // A←J^T*A*J 
						timesJ(V,p,q, theta); // V←V*J
					}
				}
			}
		}while(changed);
		return sweeps;
	}




}
