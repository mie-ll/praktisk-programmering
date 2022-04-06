.PHONEY: default
default: out.txt  figure.pdf three_body_system.gif

out.txt: main.exe
	mono $<  | sed 's/,/./g' > $@

figure.pdf: out.txt
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set grid \n\
	set title 'Three body problem' \n\
	set key left top \n\
	plot [] [] 'out.txt' using 2:3 with lines title 'Planet 1', \
		'out.txt' using 6:7 with lines title 'Planet 2', \
		 'out.txt' using 10:11 with lines title 'Planet 3'\n\
	" | tee log.gpi | gnuplot

three_body_system.gif: three_body.gpi
	gnuplot $<


main.exe: main.cs matrix.dll vector.dll ode.dll genlist.dll
	mcs $< -target:exe -reference:matrix.dll -reference:vector.dll -reference:ode.dll -reference:genlist.dll


ode.dll: ../B/ode.cs matrix.dll vector.dll genlist.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:matrix.dll -reference:vector.dll -reference:genlist.dll

matrix.dll: ../../linearequations/A/matrix.cs vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:vector.dll
 
vector.dll: ../../linearequations/A/vector.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library

genlist.dll: ../../genericlist/B/genlist.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library


PHONEY: clean
clean: 
	rm -f *.txt *.dll *.exe *.pdf
