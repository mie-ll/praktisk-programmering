all: Out.txt
	cat $<

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs vec.dll
	mcs main.cs -target:exe -out:main.exe -reference:vec.dll main.cs

vec.dll:vec.cs
	mcs -target:library -out:vec.dll vec.cs

clean:
	rm -rf Out.txt main.exe
