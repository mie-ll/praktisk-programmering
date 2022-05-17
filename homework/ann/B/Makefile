.PHONEY: default
default: out.txt figure.pdf

out.txt: main.exe
	mono $< | sed 's/,/./g' > $@

main.exe: main.cs vector.dll matrix.dll mini.dll ann.dll
	mcs $< -target:exe -reference:matrix.dll -reference:ann.dll -reference:vector.dll -reference:mini.dll

ann.dll: ann.cs mini.dll matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll  -reference:vector.dll -reference:mini.dll

mini.dll: ../../minimization/A/mini.cs matrix.dll vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:vector.dll -reference:matrix.dll

matrix.dll: ../../linearequations/A/matrix.cs vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:vector.dll

vector.dll: ../../linearequations/A/vector.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library

figure.pdf: out.txt
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'g(x)' \n\
	set grid \n\
	set title 'Interpolation' \n\
	set key left top \n\
	plot [] [] 'out.txt' index 0 using 1:2 with points title 'Tabulated points', \
		'out.txt' index 1 using 1:2 with lines title 'ANN',\
		'out.txt' index 1 using 1:3 with lines title 'Derivative',\
		'out.txt' index 1 using 1:4 with lines title 'Anti-derivative' \n\
	" | tee log.gpi | gnuplot


PHONEY: clean
clean:
	rm -f *.txt *.exe
