namespace SGConsole.Models;

public class CustomerModel : IMapFrom<Customer>
{
    public void Mapping()
    {
        Console.WriteLine("Customer Model Mapping");
    }
}

public class Customer
{

}