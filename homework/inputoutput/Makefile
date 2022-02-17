all: out_stdin.txt out_cmdline.txt out_fileio.txt
	cat out_stdin.txt out_cmdline.txt out_fileio.txt

#Del a
out_stdin.txt: stdin.exe
	echo 1 2 3 4 5 | mono stdin.exe > out_stdin.txt

stdin.exe: stdin.cs
	mcs -target:exe stdin.cs

#Del b
out_cmdline.txt: cmdline.exe
	mono cmdline.exe 1 2 3 4 5 > out_cmdline.txt

cmdline.exe: cmdline.cs
	mcs -target:exe cmdline.cs

#Del c
out_fileio.txt: fileio.exe input.txt
	mono fileio.exe -input:input.txt -output:out_fileio.txt

fileio.exe: fileio.cs
	mcs -target:exe fileio.cs

PHONY: clean
clean:
	rm *.exe [Oo]ut*
