.PHONEY: default
default: out.txt  figure.pdf 

out.txt: main.exe
	mono $<  | sed 's/,/./g' > $@

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


figure.pdf: out.txt
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set xlabel 't' \n\
	set ylabel 'amplitude' \n\
	set grid \n\
	set title 'Damped Oscillator solution' \n\
	set key left top \n\
	plot [0:10] [] 'out.txt' index 0 using 1:2 with lines title 'thatet(t) - one-step', \
		'out.txt' index 0 using 1:3 with lines title 'omega(t) - one-step', \
		'out.txt' index 1 using 1:2 with lines title 'thatet(t) - two-step', \
		'out.txt' index 1 using 1:3 with lines title 'omega(t) - two-step' \n\
	" | tee log.gpi | gnuplot



.PHONEY:clean
clean: 
	rm -f out.txt *.exe *.dll *.pdf


