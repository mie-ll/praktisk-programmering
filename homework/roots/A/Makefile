out.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs $< -target:exe

PHONEY: clean
clean:
	rm -f *.txt *.exe
