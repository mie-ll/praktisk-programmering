using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(){
		//See wiki for three-body problem
		Func<double,vector,vector> f = delegate(double x, vector y){
			double rx1 = y[0], ry1 = y[1]; //Making vectors for the three bodiyes position
			vector r1 = new vector(rx1, ry1);
			double vx1 = y[2], vy1 = y[3];
			vector v1 = new vector(vx1, vy1);
			double rx2 = y[4], ry2 = y[5];
			vector r2 = new vector(rx2, ry2);
			double vx2 = y[6], vy2 = y[7];
			vector v2 = new vector(vx2, vy2);
			double rx3 = y[8], ry3 = y[9];
			vector r3 = new vector(rx3, ry3);
			double vx3 = y[10], vy3 = y[11];
			vector v3 = new vector(vx3, vy3);
			
			//dv_j/dt =sum_i (r_j-r_i)/|r_j-r_i|^3 (all constants = 1)
			vector dv1dt = -(r1-r2)/Pow((r1-r2).norm(), 3) - (r1-r3)/Pow((r1-r3).norm(), 3);
			vector dv2dt = -(r2-r1)/Pow((r2-r1).norm(), 3) - (r2-r3)/Pow((r2-r3).norm(), 3);
			vector dv3dt = -(r3-r1)/Pow((r3-r1).norm(), 3) - (r3-r2)/Pow((r3-r2).norm(), 3);
			
			double[] k = new double[12] {v1[0], v1[1], dv1dt[0], dv1dt[1], 
			       	      v2[0], v2[1], dv2dt[0], dv2dt[1],
				      v3[0], v3[1], dv3dt[0], dv3dt[1]};
			
			return new vector(k);
		};

		double begin = 0, end = 10;


		//Constants from: http://www.artcompsci.org/msa/web/vol_1/v1_web/node45.html
		double rx10 = 0.9700436, ry10 = -0.24308753;
		double vx10 = 0.466203685, vy10 = 0.43236573;
		double rx20 = -rx10, ry20 = -ry10;
		double vx20 = vx10, vy20 = vy10;
		double rx30 = 0.0, ry30 = 0.0;
		double vx30 = -2*vx10, vy30 = -2*vy10;

		double[] k0 = new double[] {rx10, ry10, vx10, vy10,
					rx20, ry20, vx20, vy20,
					rx30, ry30, vx30, vy30};

		
		vector y0 = new vector(k0);
		genlist<double> xlist = new genlist<double>();
		genlist<vector> ylist = new genlist<vector>();
		vector yend = ode.driver(f, begin, y0, end, xlist, ylist);
		for(int i=0; i<xlist.size; i++){
			Write($"{xlist.data[i]} ");
			for(int j=0; j<ylist.data[0].size; j++){
				Write($"{ylist.data[i][j]} ");
			}
			Write("\n");
		}

	}
}
