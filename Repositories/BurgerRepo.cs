using System;
using System.Collections.Generic;
using System.Data;
using Burgershackapi.Models;
using Dapper;

namespace Burgershackapi.Repositories
{
  public class BurgerRepo
  {
    private readonly IDbConnection _db;
    public BurgerRepo(IDbConnection db)
    {
      _db = db;
    }


    internal IEnumerable<Burger> Get()
    {
      string sql = "SELECT * FROM burgers";
      return _db.Query<Burger>(sql);
    }

    internal Burger GetbyId(int id)
    {
      string sql = "SELECT * FROM burgers";
      return _db.QueryFirstOrDefault<Burger>(sql, new { id });
    }

    internal Burger Create(Burger newBurger)
    {
      string sql = @"
      INSERT INTO burgers
      (name,ingredients,price)
      VALUES
      (@Name, @Ingredients, @Price);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newBurger);
      newBurger.Id = id;
      return newBurger;
    }

    internal void Edit(Burger burgerUpdate)
    {
      string sql = @"
      UPDATE burgers
      SET
      name - @Name,
      ingredients = @Ingredients,
      price = @Price
      WHERE id = @Id;
      ";
      _db.Execute(sql, burgerUpdate);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM burgers WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}