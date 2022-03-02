
3Dgamma.gnuplot.png: 3Dgamma.data.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set zlabel 'z' \n\
	set title '3D Gamma function' \n\
	set dgrid3d 50,50 qnorm 2 \n\
	set hidden3d \n\
	set xyplane at -1 \n\
	splot [-5:5] [-5:5] [0:20] '$<' index 0 using 2:1:3 with lines title 'abs(Gamma(z))', \n\
	"| tee log.gpi | gnuplot

3Dgamma.data.txt: main.exe
	mono $< | sed 's/,/./g' > $@

%.exe: %.cs cmath.dll
	mcs $< -target:exe -reference:cmath.dll

CMATHDIR = /Users/mielauridsen/Desktop/Praktiske-programmering-og-numeriske-metoder/praktisk-programmering/exercises/complex
cmath.dll: $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^

