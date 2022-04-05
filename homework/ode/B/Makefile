.PHONEY: default
default: out.txt  figure.pdf

out.txt: main.exe
	mono $<  | sed 's/,/./g' > $@

figure.pdf: out.txt
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set xlabel 't' \n\
	set ylabel 'amplitude' \n\
	set grid \n\
	set title 'Damped Oscillator solution' \n\
	set key left top \n\
	plot [0:10] [] 'out.txt' index 0 using 1:2 with lines title 'thatet(t)', \
		'out.txt' index 0 using 1:3 with lines title 'omega(t)' \n\
	" | tee log.gpi | gnuplot


main.exe: main.cs matrix.dll vector.dll ode.dll genlist.dll
	mcs $< -target:exe -reference:matrix.dll -reference:vector.dll -reference:ode.dll -reference:genlist.dll


ode.dll: ode.cs matrix.dll vector.dll genlist.dll
	mcs $< -target:library -reference:matrix.dll -reference:vector.dll -reference:genlist.dll

matrix.dll: ../../linearequations/A/matrix.cs vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:vector.dll
 
vector.dll: ../../linearequations/A/vector.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library

genlist.dll: ../../genericlist/B/genlist.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library


PHONEY: clean
clean: 
	rm -f *.txt *.dll *.exe *.pdf
