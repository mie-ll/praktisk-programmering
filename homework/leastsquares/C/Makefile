.PHONEY: default
default: out.txt plot_fit.pdf

out.txt: main.exe
	mono $< | sed 's/,/./g' > $@

plot_fit.pdf: out.txt
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set xlabel 'Time[days]' \n\
	set ylabel 'Activity[rel. units]' \n\
	set grid \n\
	set key left top \n\
	plot [] [] 'out.txt' index 0 using 1:2:3 with yerrorbars title 'Data', \
		'out.txt' index 1 using 1:2 with lines title 'Best fit', \
		'out.txt' index 1 using 1:3 with lines title 'Best fit + unc', \
		'out.txt' index 1 using 1:4 with lines title 'Best fit - unc' \n\
	" | tee log.gpi | gnuplot


main.exe: main.cs matrix.dll vector.dll lineq.dll lsfit.dll
	mcs $< -target:exe -reference:matrix.dll -reference:lineq.dll -reference:vector.dll -reference:lsfit.dll

lsfit.dll: ../B/lsfit.cs lineq.dll matrix.dll vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:lineq.dll -reference:matrix.dll -reference:vector.dll

lineq.dll: ../../linearequations/A/lineq.cs ../../linearequations/B/lineq.cs matrix.dll vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:matrix.dll -reference:vector.dll 
 
matrix.dll: ../../linearequations/A/matrix.cs vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:vector.dll
 
vector.dll: ../../linearequations/A/vector.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library

PHONEY: clean
clean: 
	rm -f *.txt *.dll *.exe *.pdf

