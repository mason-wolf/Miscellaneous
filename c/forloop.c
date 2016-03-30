#include <stdio.h>

// exercise 1.5

int main() {
	
	int fahr;
	
	// assign fahr the value of 300
	// while fahr is greater than or equal to 0, set the value
	// of fahr to its current value - 20

	for(fahr = 300; fahr >= 0; fahr = fahr - 20) {
		printf("%3d %6.1f\n", fahr, (5.0 /9.0) * (fahr - 32));
	}
	
	// %3d - prints as decimal integer at least 3 characters wide
	// %6.1f - prints as floating point, at least 6 wide and 1 after decimal point
}


