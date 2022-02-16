all: Out.txt
	cat $<

Out.txt: main.exe
	mono $< > $@

main.exe : main.cs cmath.dll
	mcs -reference:cmath.dll main.cs

clean:
	rm -rf Out.txt main.exe

CMATHDIR = /Users/mielauridsen/Desktop/Praktiske-programmering-og-numeriske-metoder/praktisk-programmering/exercises/complex
cmath.dll : $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^ # note "./" in front of cmath.dll
