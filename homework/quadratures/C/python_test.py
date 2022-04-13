import numpy as np
from scipy import integrate

def function1(x):
	return np.exp(-x**2)

def function2(x):
	return 1/(1+x**2)

def function3(x):
	return 1/(x**2)

result1, error1, infodict1 = integrate.quad(function1, -np.inf, np.inf, epsabs=0.001, epsrel=0.001, full_output=True)
result2, error2, infodict2 = integrate.quad(function2, -np.inf, 0, epsabs=0.001, epsrel=0.001, full_output=True)
result3, error3, infodict3 = integrate.quad(function3, 1, np.inf, epsabs=0.001, epsrel=0.001, full_output=True)

print("Integration of exp(-x^2) from -infinite to +infinite = " + str(result1) + " and took " + str(infodict1['neval']) + " iterations")
print("Integration of 1/(1+x^2) from -infinite to 0 = " + str(result2) + " and took " + str(infodict2['neval']) + " iterations")
print("Integration of 1/x^2 from 1 to +infinite = " + str(result3) + " and took " + str(infodict3['neval']) + " iterations")



