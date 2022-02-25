gamma.gnuplot.png: gamma.data.txt gamma.tab.txt Makefile
	echo "\
        set terminal png \n\
        set output '$@' \n\
        set xlabel 'x' \n\
        set ylabel 'y' \n\
        set key left top \n\
        set title 'Gamma function' \n\
        plot [-0:5] [-0:5] '$<' index 0 using 1:2 with lines title 'Gamma function',\
        'gamma.tab.txt' with points title 'tab' \n\
        "| tee log.gpi | gnuplot

gamma.tab.txt: Makefile
	echo 1 1 >$@
	echo 2 1 >>$@
	echo 3 2 >>$@
	echo 4 6 >>$@

gamma.data.txt: main.exe
	mono $< | sed 's/,/./g' > $@
# | sed 's/,/./g' er nødvendig da min mac laver dansk komma(,), men her kræver det at det er engelske ko>

%.exe: %.cs
	mcs $<

PHONY: clean
clean:
	rm *.exe [Oo]ut*

