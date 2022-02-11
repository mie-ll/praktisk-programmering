all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono main.exe > Out.txt

mian.exe: main.cs
	mcs main.cs 

