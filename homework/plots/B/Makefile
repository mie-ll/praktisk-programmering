.PHONEY: default
default: gamma.gnuplot.png lngamma.gnuplot.png

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

lngamma.gnuplot.png: lngamma.data.txt lngamma.tab.txt Makefile
	echo "\
        set terminal png \n\
        set output '$@' \n\
        set xlabel 'x' \n\
        set ylabel 'y' \n\
        set key left top \n\
        set title 'LnGamma function' \n\
        plot [-0:50] [-1:160] '$<' index 0 using 1:2 with lines title 'LnGamma function',\
        'lngamma.tab.txt' with points title 'tab' \n\
        "| tee log.gpi | gnuplot

lngamma.tab.txt: Makefile
	echo 5 4.78 >$@
	echo 10 15.1 >>$@
	echo 15 27.9 >>$@
	echo 20 42.3 >>$@

gamma.data.txt: main.exe
	mono $< | sed 's/,/./g' > $@
# | sed 's/,/./g' er nødvendig da min mac laver dansk komma(,), men her kræver det at det er engelske ko>

lngamma.data.txt: lngam.exe
	mono $< | sed 's/,/./g' > $@

%.exe: %.cs
	mcs $<

PHONY: clean
clean:
	rm *.exe [Oo]ut*

