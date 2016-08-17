
#include<stdio.h>

void main()
{
	FILE *f1;
	char p[100][100],c;
	f1=fopen("abc.txt","a");
	int i=0,j;
	do
	{

		scanf("%s",p[i]);
		if((strcmp(p[i],"./save"))==0)
		{
			fseek(f1,0L,0);
			i--;
			for(j=0;j<=i;j++)
			{
				fprintf(f1,"%s",p[j]);
				putc(' ',f1);
				
			}

		}

	}

	while(strcmp(p[i++],"./exit")!=0);

	fclose(f1);

	f1=fopen("abc.txt","r");
	while((c=getc(f1))!=EOF)
	{
		printf("%c",c);
	}

	fclose(f1);
}
