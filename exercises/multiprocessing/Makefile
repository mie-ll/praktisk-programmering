all: out.txt
	cat $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs $< -target:exe

clean:
	rm -r *.exe [Oo]ut.*
