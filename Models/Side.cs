namespace Burgershackapi.Models
{
  public class Side
  {
    public Side(int id, string name, bool hot, double price)
    {

      Name = name;
      Hot = hot;
      Price = price;
    }
    public Side() { }
    public int Id { get; set; }
    public string Name { get; set; }

    public bool Hot { get; set; }

    public double Price { get; set; }
  }
}