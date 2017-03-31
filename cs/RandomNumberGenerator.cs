using System;

class dice {
	static int roll(int a, int b) {
		int y;
		Random x = new Random();
		y = x.Next(a , b);
		return y;
	}
	
	static void Main() {
		int rnd = roll(1 , 10);
		Console.WriteLine(rnd);
		Console.ReadLine();
	}
}
