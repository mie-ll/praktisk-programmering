Out.txt : hello.exe		 #out.txt depends on the hello.exe
	mono hello.exe > Out.txt #run hello.exe and sends output to Out.txt

hello.exe : hello.cs		 #hello.exe depends on hello.cs
	mcs hello.cs		 #compiles hello.cs into hello.exe

.PHONEY:clean			 #so the does not look after a clean file
clean: 				 #a phoney target, there has no dependencies
	rm -f out.txt hello.exe	 #reomes secondary files
