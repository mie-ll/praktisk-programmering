erf.gnuplot.png: out.txt 
	echo "\
        set terminal png \n\
        set output '$@' \n\
        set xlabel 'x' \n\
        set ylabel 'y' \n\
        set key left top \n\
        set title 'Error function' \n\
        plot [] [] '$<' index 1 using 1:2 with lines title 'Error function' \n\
        "| tee log.gpi | gnuplot

out.txt: main.exe
	mono $< | sed 's/,/./g' > $@

main.exe: main.cs integrate.dll
	mcs $< -target:exe -reference:integrate.dll

integrate.dll: integrate.cs
	mcs $< -target:library

PHONEY: clean
clean: 
	rm -r out.txt *.dll *.exe *.png



