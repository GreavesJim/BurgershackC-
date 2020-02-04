using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Burgershackapi.Services;
using Burgershackapi.Models;

namespace Burgershackapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BurgerController : ControllerBase
  {
    private readonly BurgersServices _cs;
    public BurgerController(BurgersServices cs)
    {
      _cs = cs;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Burger>> Get()
    {
      try
      {
        return Ok(_cs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Burger> Get(int id)
    {
      try
      {
        return Ok(_cs.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{Id}")]
    public ActionResult<Burger> Edit(int id, [FromBody]Burger burgerUpdate)
    {
      try
      {
        burgerUpdate.Id = id;
        return Ok(_cs.Edit(burgerUpdate));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Burger> Create([FromBody] Burger newBurger)
    {
      try
      {
        return Ok(_cs.Create(newBurger));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        return Ok(_cs.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}