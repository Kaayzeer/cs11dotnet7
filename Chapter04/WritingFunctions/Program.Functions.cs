internal partial class Program
{
    private static void TimesTable(byte number, byte size = 12)
    {
        WriteLine($"This is the {number} times table with {size} rows:");
        for (var row = 1; row <= size; row++) WriteLine($"{row} x {number} = {row * number}");
        WriteLine();
    }

    private static decimal CalculateTax(
        decimal amount, string twoLetterRegionCode)
    {
        var rate = twoLetterRegionCode switch
        {
            "CH" => // Switzerland
                0.08M,
            "DK" => // Denmark
                0.25M,
            "NO" => // Norway
                0.25M,
            "GB" => // United Kingdom
                0.2M,
            "FR" => // France
                0.2M,
            "HU" => // Hungary
                0.27M,
            "OR" => // Oregon
                0.0M,
            "AK" => // Alaska
                0.0M,
            "MT" => // Montana
                0.0M,
            "ND" => // North Dakota
                0.05M,
            "WI" => // Wisconsin
                0.05M,
            "ME" => // Maine
                0.05M,
            "VA" => // Virginia
                0.05M,
            "CA" => // California
                0.0825M,
            _ => 0.06M
        };

        return amount * rate;
    }

    /// <summary>
    /// Pass a 32-bit integer and it will be converted into its ordinal equivalent.
    /// </summary>
    /// <param name="number">Number is a cardinal value e.g. 1, 2, 3, and so on.</param>
    /// <returns>Number as an ordinal value e.g. 1st, 2nd, 3rd, and so on.</returns>
    static string CardinalToOrdinal(int number)
    {
        int lastTwoDigits = number % 100;
        switch (lastTwoDigits)
        {
            case 11: // special cases for 11th to 13th
            case 12:
            case 13:
                return $"{number:N0}th";
            default:
                int lastDigit = number % 10;
                string suffix = lastDigit switch
                {
                    1 => "st",
                    2 => "nd",
                    3 => "rd",
                    _ => "th"
                };
                return $"{number:N0}{suffix}";
        }
    }

    static void RunCardinalToOrdinal()
    {
        for (int number = 1; number <= 150; number++)
        {
            Write($"{CardinalToOrdinal(number)} ");
        }
        WriteLine();
    }

    static int Factorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException(message:$"The factorial function is defined for non-negative integers only. Input: { number }",
            paramName: nameof(number));
        }
        else if (number == 0)
        {
            return 1;
        }
        else
        {
            checked // for overflow
            {
                return number * Factorial(number - 1);
            }
        }
    }

    static void RunFactorial()
    {
        for (int i = 1; i <= 15; i++)
        {
            try
            {
                WriteLine($"{i}! = {Factorial(i):N0}");
            }
            catch (OverflowException)
            {
                WriteLine($"{i}! is too big for a 32-bit integer.");
            }
            catch (Exception ex)
            {
                WriteLine($"{i}! throws {ex.GetType()}: {ex.Message}");
            }
        }
    }



}