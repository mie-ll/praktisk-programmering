
cspline_gnuplot.png: out.txt
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set grid \n\
	set key left top \n\
	plot [-5.5:5.5] [] 'out.txt' index 0 using 1:2 with points title 'Tabulated', \
	'out.txt' index 1 using 1:2 with lines title 'Quadratic interpolation', \
	'out.txt' index 1 using 1:3 with lines title 'Integral', \
	'out.txt' index 1 using 1:4 with lines title 'Derivativ', \
	'out.txt' index 1 using 1:2 smooth csplines \n\
	" | tee log.gpi | gnuplot

out.txt: main.exe
	mono $< | sed 's/,/./g' > $@

main.exe: main.cs cspline.dll
	mcs $< -target:exe -reference:cspline.dll

cspline.dll: cspline.cs
	mcs $< -target:library

PHONEY: clean
clean: 
	rm -r out.txt *.dll *.exe *.png
