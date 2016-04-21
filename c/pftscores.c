/* 
unnofficial USAF physical fitness score calculator
		Mason H. Wolf, 2016
demonstrates the use of concepts covered in ch. 1
of the k&r:	
		- variables and arithmetic expressions
		- the for statement
		- character input and output
		- arrays
		- functions
		- arguments, call by calue
		- character arrays
		- external variables and scope
*/

#include <stdio.h>

char runtime[5], waist[3], pushups[3], situps[3], i;

int timerange[25] =      { 	 912, 934, 945, 958, 1010, 1023, 1037, 1051,
				 1106, 1122, 1138, 1156, 1214, 1233, 1253,
				 1314, 1336, 1400, 1425, 1452, 1520, 1550,
				 1622, 1657, 1658			};
				   
float timescore[] =      {	 60, 59.7, 59.3, 58.9, 58.5, 57.9, 57.3,
			         56.6, 55.7, 54.8, 53.7, 52.4,
				 50.9, 49.2, 47.2, 44.9, 42.3, 0	};

int waistMeasurement[] = { 	 32.5, 33, 33.5, 34, 34.5, 35, 35.5, 36, 
				 36.5, 37, 37.5, 38, 38.5, 39 		};
						
float waistscore[] =     {	 20, 20, 20, 20, 20, 20, 17.6, 17, 16.4,
				 15.8, 15.1, 14.4, 13.5, 12.6 		};
							 
int pushuprange[] =    	 {	 67, 62, 61, 60, 59, 58, 57, 56, 55, 54,
				 53, 52, 51, 50, 49, 48, 47, 46, 45, 44,
				 43, 42, 41, 40, 39, 38, 37, 36, 35, 34,
				 33					};
							 
float pushupscore[] =	{	 10, 9.5, 9.4, 9.3, 9.2, 9.1, 9, 8.9, 8.8,
				 8.8, 8.7, 8.6, 8.5, 8.4, 8.3, 8.1, 8,
				 7.8, 7.7, 7.5, 7.3, 7.2, 7, 6.8, 6.5, 6.3,
				 6, 5.8, 5.5, 5.3, 5			};
							 
int situprange[] =	{        8, 55, 54, 53, 52, 51, 50, 49, 48, 47, 46,
				 45, 44, 43, 42				};
							 
float situpscore[] =	{	 10, 9.5, 9.4, 9.2, 9.0, 8.8, 8.7, 8.5, 8.3,
				 8.0, 7.5, 7.0, 6.5, 6.3, 6.0		};
		
int trs[25];
int trscore, wgrade, pgrade, sgrade;

/* removeChar() - function to handle the time input and strip the colon
remember: a pointer is a variable whose value is the address of another
variable, in this case the address location is where the 'runtime' variable 
is stored, defining *str (string to recieve) garbage is the character to remove
*/

void removeChar(char *str, char garbage) {			
													
    char *src, *dst;								
    for (src = dst = str; *src != '\0'; src++) {	
        *dst = *src;
        if (*dst != garbage) dst++;
    }
    *dst = '\0';
}

int findIndex( const int a[], size_t size, int value )
{
    size_t index = 0;

    while ( index < size && a[index] != value ) ++index;

    return ( index == size ? -1 : index );
}

main() {
	int indexToRemove = 2;
	printf("\nEnter runtime xx:xx:");	
	scanf("%s", runtime);				
	
	for(i = 0; runtime[i]!='\0'; ++i);
	if(i > 5) {
		printf("Incorrect time format. Enter as xx:xx. ex: 09:25");
	}
	else {
		removeChar(runtime, ':'); 
		int runtimeint = atoi(runtime);
			for (i = 0; i < sizeof(timerange) / sizeof(timerange[0]); i++) {
				if(runtimeint <= timerange[i]) {
					trs[i] = timerange[i];
					for (i = 0; i < sizeof(trs) / sizeof(trs[0]); i++) {
						if(trs[i] > 0) {
							trscore += trs[i];
						}
					}
				}
			}
	}
			 int ri = findIndex(timerange, 25, trscore);
			 
		 	 printf("\nEnter waist measurement: ");
			 scanf("%s", waist);	
			
			 int w = atoi(waist);
			 wgrade = findIndex(waistMeasurement, 17, w);
			 if(wgrade == -1) {
				 if(w < 32) {
					 waistscore[wgrade] = 20;
				 }
			 }
			 		
			 printf("\nEnter pushups: ");
			 scanf("%s", pushups);
			 
			 int p = atoi(pushups);

			 pgrade = findIndex(pushuprange, 31, p);
			 if(pgrade == -1) {
				 if(p > 67) {
					 pushupscore[pgrade] = 10;
				 }
			 }
			 
			 printf("\nEnter situps: ");
			 scanf("%s", situps);
			 
			 int s = atoi(situps);
			 sgrade = findIndex(situprange, 14, s);
			 if(sgrade == -1) {
				 if(s > 58) {
					 situpscore[sgrade] = 10;
				 }
			 }
			 
			 float totalscore = timescore[ri] + waistscore[wgrade] + pushupscore[pgrade] + situpscore[sgrade];	
			 printf("\nRun Time Score: %.1f\nWaist Score: %.1f\nPushup Score: %.1f\nSitup Score: %.1f\n", timescore[ri],
			 waistscore[wgrade], pushupscore[pgrade], situpscore[sgrade]);
			 printf("\nTotal Score: %.1f", totalscore);
}

