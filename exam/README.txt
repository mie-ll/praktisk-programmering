Praktisk programmering og numeriske metoder eksamen 2022

Number 88%23=19 =>

Exam projekc 19:
	ODE: a two-step method
	Implement a two-step stepper for solving ODE (as in the book). Use your own stepsize controlling driver.

All source files for this project are found in the folder/directory A. 

Description:
In this project I have implemented an method for using the two-step method: 
	y(x) =y_i+y_i'(x-x_i)+c(x-x_i)^2.
The multiple step method uses the information gathered from the previous steps. 
Since they are not self-starting, the two-step method here is started using a one-step method(Runge-Kutta).
The two-step method is implemented as in the note "ode.pdf".
The used Runge-Kutta is a RK45. And there are used a stepsize controlling driver.
The source code for at two-step method can be seen ind ode.cs, together with the Runge-Kutta method and two drivers, one for one-step method and one for two-step method.


The implemented two-step method has been tested for 3 different ordinary differential equations. 
Here the two-step method is compared with the one-step method in the plots made for each equation, see the pdf's. 
In out.txt it is seen that the number of iterations is lower for the two-step method than for the one-step Runge-Kutta method.

Note: that genlist.cs is from a homework, and vector.cs and matrix.cs is from the available mathbib. 
My computer handle commas and period differently than other computers and therefore there ia a comma in the Makefile that makes commas(solution1.txt) to period(soultion.txt).


Self-evaluation:
The examination project was a succes. The two-step method was implemented and gave good results for different ordinary differential equations. 
Furthermore was the two-step method compared with the one-step Runge-Kutta(RK45) method, both visually and how many iterations they each maded. Which was not a part of the problem formulation.



