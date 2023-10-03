const byte max = 100;

for (byte i =1 ; i <= max; i++)
{
    if (i % 15 == 0)
    {
        Write("FizzBuzz");
    }
    else if (i % 5 == 0)
    {
        Write("Buzz");
    }
    else if (i % 3 == 0)
    {
        Write("Fizz");
    }
    else
    {
        Write($"{i}");
    }

    if (i < max)
    {
        Write(", ");
    }

    if (i % 10 == 0)
    {
        WriteLine();
    }
}
WriteLine();