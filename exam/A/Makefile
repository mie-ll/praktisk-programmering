.PHONEY: default
default: out.txt solution.txt test1.pdf test2.pdf test3.pdf

out.txt: main.exe
	mono $< 1> solution1.txt  2> out.txt

solution.txt: solution1.txt
	sed 's/,/./g' solution1.txt > solution.txt

main.exe: main.cs ode.dll matrix.dll vector.dll genlist.dll
	mcs $< -target:exe -reference:ode.dll -reference:matrix.dll -reference:vector.dll -reference:genlist.dll

ode.dll: ode.cs matrix.dll vector.dll genlist.dll
	mcs $< -target:library -reference:matrix.dll -reference:vector.dll -reference:genlist.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

genlist.dll: genlist.cs
	mcs $< -target:library

test1.pdf: solution.txt
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set xlabel 'Time' \n\
	set ylabel 'Numerical solution' \n\
	set grid \n\
	set title 'Numerical solution to differential equation: u''=-u' \n\
	set key left top \n\
	plot [0:10] [] 'solution.txt' index 0 using 1:4 with lines title 'solution', \
		'solution.txt' index 0 using 1:2 with lines title 'theta(t) - one-step', \
		'solution.txt' index 0 using 1:3 with lines dashtype 2 title 'omega(t) - one-step', \
		'solution.txt' index 1 using 1:2 with lines title 'theta(t) - two-step', \
		'solution.txt' index 1 using 1:3 with lines dashtype 4 title 'omega(t) - two-step' \n\
	" | tee log.gpi | gnuplot


test2.pdf: solution.txt
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set xlabel 'Time' \n\
	set ylabel 'Numerical solution' \n\
	set grid \n\
	set title 'Numerical solution to differential equation: d^2theta(t)/dt^2+b*dtheta(t)/dt+c*sin(theta(t))=0' \n\
	set key left top \n\
	plot [0:10] [] 'solution.txt' index 2 using 1:2 with lines title 'theta(t) - one-step', \
		'solution.txt' index 2 using 1:3 with lines title 'omega(t) - one-step', \
		'solution.txt' index 3 using 1:2 with lines dashtype 2 title 'theta(t) - two-step', \
		'solution.txt' index 3 using 1:3 with lines dashtype 2 title 'omega(t) - two-step' \n\
	" | tee log.gpi | gnuplot

test3.pdf: solution.txt
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set xlabel 'Time' \n\
	set ylabel 'Numerical solution' \n\
	set grid \n\
	set title 'Numerical solution to differential equation: d^2theta(t)/dt^2-b*dtheta(t)/dt-c*cos(theta(t))=0' \n\
	set key left top \n\
	plot [0:10] [] 'solution.txt' index 4 using 1:2 with lines title 'theta(t) - one-step', \
		'solution.txt' index 4 using 1:3 with lines title 'omega(t) - one-step', \
		'solution.txt' index 5 using 1:2 with lines dashtype 2 title 'theta(t) - two-step', \
		'solution.txt' index 5 using 1:3 with lines dashtype 2 title 'omega(t) - two-step' \n\
	" | tee log.gpi | gnuplot


.PHONEY:clean
clean: 
	rm -f *.txt *.exe *.dll *.pdf

