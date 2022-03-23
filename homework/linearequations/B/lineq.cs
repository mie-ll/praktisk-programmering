public static partial class lineq{
	
	public static matrix QRGSinverse(matrix Q, matrix R){
		int n = Q.size1;
		matrix res = new matrix(n,n);
		vector e = new vector(n);
		for(int i=0; i<n; i++){
			e[i] = 1;
			vector x = QRGSsolve(Q, R, e);
			res[i] = x;
			e[i] = 0;
		}
		return res;
	}


}
