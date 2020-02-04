
using System;
using System.Collections.Generic;
using Burgershackapi.Models;
using Burgershackapi.Repositories;

namespace Burgershackapi.Services
{
  public class BurgersServices
  {
    private readonly BurgerRepo _repo;
    public BurgersServices(BurgerRepo br)
    {
      _repo = br;
    }
    public IEnumerable<Burger> Get()
    {
      return _repo.Get();
    }
    internal Burger GetById(int id)
    {
      Burger found = _repo.GetbyId(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal object Edit(Burger burgerUpdate)
    {
      var current = _repo.GetbyId(burgerUpdate.Id);
      if (current == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Edit(burgerUpdate);
      return burgerUpdate;
    }

    internal object Create(Burger newBurger)
    {
      _repo.Create(newBurger);
      return newBurger;
    }

    internal object Delete(int id)
    {
      var current = _repo.GetbyId(id);
      if (current == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}