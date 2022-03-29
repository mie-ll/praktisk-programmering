out.txt: main.exe
	mono $< | sed 's/,/./g' > $@

main.exe: main.cs matrix.dll vector.dll
	mcs $< -target:exe -reference:matrix.dll -reference:vector.dll

matrix.dll: ../../linearequations/A/matrix.cs vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:vector.dll
 
vector.dll: ../../linearequations/A/vector.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library

PHONEY: clean
clean: 
	rm -f *.txt *.dll *.exe *.pdf

