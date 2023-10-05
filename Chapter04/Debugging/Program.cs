double a = 4.5;
double b = 2.5;
double answear = Add(a, b);

WriteLine($"{a} + {b} = {answear}");
WriteLine("Press ENTER to end the app.");
ReadLine(); // wait for press ENTER


double Add(double a, double b)
{
    return a + b; // deliberate bug!
}