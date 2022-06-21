.PHONEY: default
default: out.txt  solution.txt figure.pdf test.pdf

out.txt: main.exe
	mono $< 1> out.txt  2> solution1.txt
 
solution.txt: solution1.txt
	sed 's/,/./g' solution1.txt > solution.txt

#solution1.txt: main.exe
#	mono $<  | sed 's/,/./g' 2> $@

figure.pdf: solution.txt
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set xlabel 't' \n\
	set ylabel 'amplitude' \n\
	set grid \n\
	set title 'Damped Oscillator solution' \n\
	set key left top \n\
	plot [0:10] [] 'solution.txt' index 0 using 1:2 with lines title 'thatet(t)', \
		'solution.txt' index 0 using 1:3 with lines title 'omega(t)' \n\
	" | tee log.gpi | gnuplot

test.pdf: solution.txt
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set xlabel 't' \n\
	set ylabel 'amplitude' \n\
	set grid \n\
	set title 'test of u''=-u' \n\
	set key left top \n\
	plot [0:10] [] 'solution.txt' index 1 using 1:2 with lines title 'theta(t)', \
		'solution.txt' index 1 using 1:3 with lines title 'omega(t)'  \n\
	" | tee log2.gpi | gnuplot

main.exe: main.cs matrix.dll vector.dll ode.dll
	mcs $< -target:exe -reference:matrix.dll -reference:vector.dll -reference:ode.dll

ode.dll: ode.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll -reference:vector.dll

matrix.dll: ../../linearequations/A/matrix.cs vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:vector.dll
 
vector.dll: ../../linearequations/A/vector.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library

PHONEY: clean
clean: 
	rm -f *.txt *.dll *.exe *.pdf
