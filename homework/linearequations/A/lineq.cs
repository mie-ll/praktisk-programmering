
public static partial class lineq{
	public static void QRGSdecomp(matrix A, matrix R){
		int m = A.size2;
		for(int i=0; i<m; i++){
			R[i,i] = A[i].norm();
			A[i] = A[i]/R[i,i];
			for(int j=i+1; j<m; j++){
				R[i,j] = A[i].dot(A[j]);
				A[j] -= A[i]*R[i,j];
			}
		}
	}
	
	public static vector QRGSsolve(matrix Q, matrix R, vector b){
		matrix Q_trans = Q.transpose();
		vector x = Q_trans*b;
		backsub(R,x);
		return x;
	}

	public static void backsub(matrix U, vector c){
		for(int i=c.size-1; i>=0; i--){
			double sum = 0;
			for(int k=1+i; k<c.size; k++){
				sum += U[i,k]*c[k];
			}
		c[i] = (c[i]-sum)/U[i,i];
		}
	}


}
