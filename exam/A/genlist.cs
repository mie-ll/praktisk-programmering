using static System.Console;

public class genlist<T>{
	public T[] data;
	public int size=0,capacity=8;
	public genlist(){ data = new T[capacity]; }
	public void push(T item){ /* add item to list */
		if(size==capacity){
			T[] newdata = new T[capacity*=2];
			for(int i=0;i<size;i++)newdata[i]=data[i];
			data=newdata;
			}
		data[size]=item;
		size++;
	}


	public void remove(int j){
		if(j>size-1) WriteLine($"Remove: j = {j}, size = {size}");
		for(int i=j; i<size; i++){
			data[i] = data[i+1];
	
		}
		size--;
	}



}
