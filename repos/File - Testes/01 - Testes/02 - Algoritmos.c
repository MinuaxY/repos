#include <stdio.h>

int main()
{
	int a, b, c;

	scanf("%i", &a);
	scanf("%i", &b);

	if (a >= b)
	{
		c = a + b;
	}
	else
	{
		c = b - a;
	}
	printf("%i\n", c);

	return 0;
}