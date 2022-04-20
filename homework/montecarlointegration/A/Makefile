out.txt: main.exe
	mono $< > $@

main.exe: main.cs mcintegration.dll vector.dll
	mcs $< -target:exe 

mcintegration.dll: mcintegration.cs vector.dll
	mcs $< -target:library -reference:vector.dll 

vector.dll: ../../linearequations/A/vector.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library


PHONEY: clean
clean:
	rm -f *.txt *.exe
