
using System.Collections.Generic;

public class ProductNames
{
    private List<string> names;

    public ProductNames()
    {
        names = new List<string>(){
            "IPhone 7",
            "Samsung G7",
            "Nokia 321"
        };
    }
    public List<string> GetNames() => names;
}