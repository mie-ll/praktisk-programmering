
ms.pdf: ms.tex exp_gnuplot.pdf
	pdflatex $<
	pdflatex $<

exp_gnuplot.pdf: exp.data.txt exp.tab.txt Makefile
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set size 0.6 \n\
	set grid \n\
	set tics out \n\
	set xlabel 'x' \n\
	set ylabel 'exp(x)' \n\
	set key left top \n\
	set title 'Exponetial function' \n\
	plot [-4:4] [] '$<' index 0 using 1:2 with lines title 'exp(x)',\
	'exp.tab.txt' with points title 'table values' \n\
	"| tee log.gpi | gnuplot

exp.tab.txt: Makefile
	echo -2.5 0.08 >$@
	echo -2.0 0.13 >>$@
	echo -1.5 0.23 >>$@
	echo -1.0 0.37 >>$@
	echo -0.5 0.61 >>$@
	echo 0.0 1.0 >>$@
	echo 0.5 1.65 >>$@
	echo 1.0 2.71 >>$@
	echo 1.5 4.48 >>$@
	echo 2.0 7.39 >>$@
	echo 2.5 12.2 >>$@


exp.data.txt: main.exe
	mono $< | sed 's/,/./g' > $@

%.exe: %.cs
	mcs $<

PHONEY: clean
clean:
	rm *.exe 

