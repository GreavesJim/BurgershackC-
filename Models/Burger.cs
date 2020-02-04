

namespace Burgershackapi.Models
{
  public class Burger
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Ingredients { get; set; }

    public double Price { get; set; }
    public Burger() { }

    public Burger(string name, double price, string ingredients)
    {
      Name = name;
      Ingredients = ingredients;

      Price = price;
    }

  }
}