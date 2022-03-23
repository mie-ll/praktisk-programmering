.PHONEY: default
default: out.txt time.png

out.txt: main.exe
	mono $< | sed 's/,/./g' > $@

time.png: out.txt
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set grid \n\
	set key left top \n\
	f(x) = a*x*x*x+b \n\
	fit f(x) 'out.txt' index 0 using 1:2 via a,b \n\
	plot [] [] 'out.txt' index 0 using 1:2 with points title 'Decomposed time', \
	f(x) title 'Fit' \n\
	" | tee log.gpi | gnuplot


main.exe: main.cs matrix.dll vector.dll lineq.dll
	mcs $< -target:exe -reference:matrix.dll -reference:lineq.dll -reference:vector.dll

lineq.dll: ../A/lineq.cs ../B/lineq.cs matrix.dll vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:matrix.dll -reference:vector.dll 
 
matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll
 
vector.dll: vector.cs
	mcs $< -target:library

PHONEY: clean
clean: 
	rm -f out.txt *.dll *.exe *.png

