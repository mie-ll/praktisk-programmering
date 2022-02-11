all: Out.txt
	cat $<

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs main.cs -target:exe -out:main.exe

clean:
	rm -rf Out.txt main.exe
