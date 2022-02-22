all: out.txt
	cat out.txt

out.txt: main.exe
	mono $< > $@

main.exe: main.cs passf.dll
	mcs -target:exe -out:$@ $< -reference:passf.dll

passf.dll: passf.cs
	mcs -target:library -out:passf.dll $<

PHONY:clean
clean: 
	rm *.dll *.txt *.exe
