using System;

interface Visitor
{
    void visit(Food o);
}


interface Visitable
{
    void accept(Visitor visitor);
}

class Food : Visitable
{
    private int quantity;
    private double price;
    private string[] foodname;
    public Food(int t, double m, string[] a)
    {
        quantity = t;
        price = m;
        foodname = a;
    }
   

    public void accept(Visitor visitor)
    {
        visitor.visit(this);
    }

    public string[] FoodName
    {
        get { return foodname; }
    }
    public int OldQuantity
    {
        get { return quantity; }
    }

    public double OldPrice
    {
        get { return price; }
    }

    public void print_details()
    {
        Console.WriteLine("Food:= " + foodname);

        foreach (string element in foodname)
            Console.Write(" " + element);
        Console.WriteLine();
    }
}

class MoreFunctions : Visitor
{
    Food sub;
    public void visit(Food o)
    {
        this.sub = o;
    }

    public int newQuantity()
    {
        int res = sub.OldQuantity+3;
        //foreach (string element in sub.FoodName)
           // if (element < res) res = element;
        return res;
    }
    public double newPrice()
    {
        double res = sub.OldPrice + (sub.OldPrice * 0.1);
        //foreach (string element in sub.FoodName)
        // if (element < res) res = element;
        return res;
    }

}

public class QVisitor
{
    public static void Main(string[] args)
    {
        string[] m = { "pizza", "burger", "french fries" };
        Console.WriteLine("Enter the price of pizza");
        double localPrice = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the quantity of pizza");
        int localQuan = Convert.ToInt32(Console.ReadLine());
        //double localPrice = 500;
        //int localQuan = 10;
        Food s = new Food(localQuan, localPrice, m);
        //s.print_details();
        Console.WriteLine("\n The local meal Price is  "
                          + s.OldPrice);
        Console.WriteLine("\n The local meal Quantity is  "
                          + s.OldQuantity);
        MoreFunctions mf = new MoreFunctions();
        s.accept(mf);
        Console.WriteLine("New Price: "
                          + mf.newPrice());
        Console.WriteLine("New Quantity: "
                          + mf.newQuantity());

    }
}
