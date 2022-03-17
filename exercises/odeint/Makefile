
ode.gnuplot.png: out.txt 
	echo "\
        set terminal png \n\
        set output '$@' \n\
        set xlabel 't' \n\
        set ylabel 'solution' \n\
        set key left top \n\
        set title 'Error function' \n\
        plot [] [] 'out.txt' index 0 using 1:2 with lines title 'theta (t)', \
	'out.txt' index 0 using 1:3 with lines title 'omega (t)' \n\
        "| tee log.gpi | gnuplot

out.txt: main.exe
	mono $< | sed 's/,/./g' > $@

main.exe: main.cs vector.dll ode.dll 
	mcs -target:exe -reference:vector.dll -reference:ode.dll $< 

ode.dll: ode.cs vector.dll
	mcs -target:library -reference:vector.dll $<

vector.dll: vector.cs
	mcs -target:library $<

.PHONY:
clean:
	rm -f *.exe *.dll *.txt 



