/*string rowSeparator = new string('-', count: 74);
WriteLine(rowSeparator);
WriteLine("Type    Byte(s) of memory               Min                            Max");
WriteLine(rowSeparator);
WriteLine($"sbyte   {sizeof(sbyte),-4} {sbyte.MinValue,30} {sbyte.MaxValue,30}");
WriteLine($"byte    {sizeof(byte),-4} {byte.MinValue,30} {byte.MaxValue,30}");
WriteLine($"short   {sizeof(short),-4} {short.MinValue,30} {short.MaxValue,30}");
WriteLine($"ushort  {sizeof(ushort),-4} {ushort.MinValue,30} {ushort.MaxValue,30}");
WriteLine($"int     {sizeof(int),-4} {int.MinValue,30} {int.MaxValue,30}");
WriteLine($"uint    {sizeof(uint),-4} {uint.MinValue,30} {uint.MaxValue,30}");
WriteLine($"long    {sizeof(long),-4} {long.MinValue,30} {long.MaxValue,30}");
WriteLine($"ulong   {sizeof(ulong),-4} {ulong.MinValue,30} {ulong.MaxValue,30}");
WriteLine($"float   {sizeof(float),-4} {float.MinValue,30} {float.MaxValue,30}");
WriteLine($"double  {sizeof(double),-4} {double.MinValue,30} {double.MaxValue,30}");
WriteLine($"decimal {sizeof(decimal),-4} {decimal.MinValue,30} {decimal.MaxValue,30}");
WriteLine(rowSeparator);*/


// Denna kod är som att skapa ett virtuellt butiksspel där du kan handla olika produkter.
// Vi kommer att gå igenom varje del av koden.

// Här börjar vi med att skapa en lista av produkter. En produkt har ett namn, ett pris och en lagerstatus.
// Det är som att ha en lista med saker som du kan köpa i butiken.
class Product
{
    public string Name { get; }   // Namn på produkten, t.ex. "Högtalare".
    public double Price { get; }  // Priset på produkten, t.ex. 10.99 dollar.
    public int Stock { get; set; } // Lagerstatus, hur många av produkten som finns tillgängliga.

    // Här skapar vi en produkt med ett namn, ett pris och en lagerstatus.
    public Product(string name, double price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }

    // Denna funktion låter oss fylla på lagret med fler produkter. Som att lägga till fler varor i butiken.
    public void Restock()
    {
        // Simulerar att vi fyller på lagret med 10 fler av samma produkt.
        Stock += 10;
    }
}

// Här skapar vi en "kundvagn" där vi kan lägga till produkter som vi vill köpa.
class CartItem
{
    public Product Product { get; }

    // När vi lägger till en produkt i kundvagnen, behöver vi veta vilken produkt det är.
    public CartItem(Product product)
    {
        Product = product;
    }
}

// Här skapar vi en "order" som innehåller de produkter vi har köpt och det totala priset för ordern.
class Order
{
    public List<CartItem> Items { get; }
    public double Total { get; }

    // När vi skapar en order, behöver vi veta vilka produkter som är med i ordern och det totala priset.
    public Order(List<CartItem> items, double total)
    {
        Items = items;
        Total = total;
    }
}

// Här skapar vi två speciella typer av "fel" som kan hända när vi handlar: 
// Om en produkt är slut i lagret ("OutOfStockException") eller om vi inte har tillräckligt med pengar ("InsufficientFundsException").
class OutOfStockException : Exception
{
    public OutOfStockException(string message) : base(message)
    {
    }
}

class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message)
    {
    }
}

// Här skapar vi en "kundvagn" där vi kan lägga till produkter, visa vad som finns i kundvagnen och genomföra köp.
class ShoppingCart
{
    public List<CartItem> Items { get; } = new List<CartItem>(); // Här sparar vi produkterna vi har lagt i kundvagnen.
    public List<Order> OrderHistory { get; } = new List<Order>(); // Här sparar vi våra tidigare köp.
    public double Funds { get; set; } = 100.00; // Här har vi pengar att använda för att köpa produkter.

    // Denna funktion låter oss lägga till en produkt i kundvagnen om den finns tillgänglig i butiken.
    public void AddToCart(Product product)
    {
        if (product.Stock > 0)
        {
            Items.Add(new CartItem(product));
            product.Stock--;
        }
        else
        {
            // Om produkten är slut i lagret, får vi ett meddelande att produkten inte kan läggas i kundvagnen.
            Console.WriteLine($"{product.Name} är slut i lagret och kan inte läggas i kundvagnen.");
        }
    }

    // Denna funktion räknar ut det totala priset för alla produkter i kundvagnen.
    public double CalculateTotal()
    {
        double total = 0;
        foreach (var item in Items)
        {
            total += item.Product.Price;
        }
        return total;
    }

    // Denna funktion låter oss genomföra ett köp om vi har tillräckligt med pengar och produkterna är tillgängliga.
    public void Checkout(List<Product> availableProducts)
    {
        double cartTotal = CalculateTotal();

        if (Funds < cartTotal)
        {
            WriteLine("Du har inte tillräckligt med pengar för att slutföra köpet.");
        }

        foreach (var item in Items)
        {
            Product product = availableProducts.Find(p => p.Name == item.Product.Name);
            if (product == null || product.Stock == 0)
            {
                WriteLine($"{item.Product.Name} är slut i lagret.");
            }
            product.Stock--; // Minskar lagret med en produkt.
        }

        OrderHistory.Add(new Order(Items, cartTotal)); // Sparar vår orderhistorik.
        Items.Clear(); // Tömmer kundvagnen efter ett lyckat köp.
        Funds -= cartTotal; // Drar av pengarna från vårt saldo.
    }

    // Denna funktion visar vad som finns i kundvagnen och det totala priset.
    public void ViewCart()
    {
        WriteLine("Varor i kundvagnen:");
        foreach (var item in Items)
        {
            WriteLine($"{item.Product.Name} - ${item.Product.Price}");
        }
        WriteLine($"Total kostnad: ${CalculateTotal()}");
    }

    // Denna funktion visar vår köphistorik och vad vi har köpt tidigare.
    public void ViewOrderHistory()
    {
        WriteLine("Köphistorik:");
        foreach (var order in OrderHistory)
        {
            WriteLine($"Order Total: ${order.Total}, Varor:");
            foreach (var item in order.Items)
            {
                WriteLine($"{item.Product.Name} - ${item.Product.Price}");
            }
        }
    }
}

// Här är huvudprogrammet där vi skapar produkter, kundvagnen och låter användaren interagera med butiken.
class Program
{
    static void Main()
    {
        // Skapar några exempelprodukter med namn, pris och lagerstatus.
        List<Product> products = new List<Product>
        {
            new Product("Högtalare", 10.99, 5),
            new Product("Hörlurar", 5.99, 3),
            new Product("Headset", 2.99, 10)
        };

        // Skapar en ny kundvagn.
        ShoppingCart cart = new ShoppingCart();

        // En oändlig loop som låter användaren interagera med butiken tills de väljer att avsluta.
        while (true)
        {
            
            WriteLine("Tillgängliga produkter:");
            for (int i = 0; i < products.Count; i++)
            {
                WriteLine($"{i + 1}. {products[i].Name} - ${products[i].Price} (I lager: {products[i].Stock})");
            }

            WriteLine("Alternativ:");
            WriteLine("1. Lägg till i kundvagnen");
            WriteLine("2. Visa kundvagnen");
            WriteLine("3. Köp");
            WriteLine("4. Visa köphistorik");
            WriteLine("5. Fyll på lagret");
            WriteLine("6. Avsluta");

            Write("Ange ditt val: ");
            if (int.TryParse(ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        // Lägger till en produkt i kundvagnen.
                        Write("Ange produktens nummer att lägga till i kundvagnen: ");
                        if (int.TryParse(ReadLine(), out int productChoice) && productChoice >= 1 && productChoice <= products.Count)
                        {
                            Product selectedProduct = products[productChoice - 1];
                            cart.AddToCart(selectedProduct);
                            WriteLine($"{selectedProduct.Name} har lagts till i kundvagnen.");
                        }
                        else
                        {
                            WriteLine("Ogiltigt produktnummer.");
                        }
                        break;
                    case 2:
                        // Visar kundvagnen.
                        cart.ViewCart();
                        break;
                    case 3:
                        // Utför ett köp.
                        try
                        {
                            cart.Checkout(products);
                            WriteLine("Köpet lyckades!");
                        }
                        catch (OutOfStockException ex)
                        {
                            WriteLine($"Fel: {ex.Message}");
                        }
                        catch (InsufficientFundsException ex)
                        {
                            WriteLine($"Fel: {ex.Message}");
                        }
                        break;
                    case 4:
                        // Visar köphistoriken.
                        cart.ViewOrderHistory();
                        break;
                    case 5:
                        // Fyller på lagret med fler produkter.
                        foreach (var product in products)
                        {
                            product.Restock();
                        }
                        WriteLine("Lagret har fyllts på.");
                        break;
                    case 6:
                        // Avslutar programmet.
                        WriteLine("Avslutar programmet.");
                        return;
                    default:
                        WriteLine("Ogiltigt val.");
                        break;
                }
            }
            else
            {
                WriteLine("Ogiltig inmatning. Ange ett nummer.");
            }
        }
    }
}
