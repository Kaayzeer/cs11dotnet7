string applesText = "Apples";
int applesCount = 1234;
string banannasText = "Banannas";
int banannasCount = 56789;

WriteLine(
    format: "{0,-10} {1,6}",
    arg0: "name",
    arg1: "Count"
);

WriteLine(
    format:"{0,-10} {1,6:N0}",
    arg0: applesText,
    arg1: applesCount
);

WriteLine(
    format: "{0,-10} {1,6:N0}",
    arg0: banannasText,
    arg1: banannasCount
);
WriteLine("Type your first name and press ENTER: ");
string ? firstName = ReadLine();
WriteLine("Type your age and press ENTER: ");
string age = ReadLine()!;
WriteLine($"Hello {firstName}, you look good for {age}.");