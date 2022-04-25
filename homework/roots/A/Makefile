out.txt: main.exe
	mono $< > $@

main.exe: main.cs roots.dll vector.dll matrix.dll lineq.dll
	mcs $< -target:exe -reference:matrix.dll -reference:lineq.dll -reference:vector.dll -reference:roots.dll

roots.dll: roots.cs matrix.dll vector.dll lineq.dll
	mcs $< -target:library -reference:vector.dll -reference:matrix.dll -reference:lineq.dll

lineq.dll: ../../linearequations/A/lineq.cs vector.dll matrix.dll
	 mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:vector.dll -reference:matrix.dll

matrix.dll: ../../linearequations/A/matrix.cs vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:vector.dll

vector.dll: ../../linearequations/A/vector.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library


PHONEY: clean
clean:
	rm -f *.txt *.exe
