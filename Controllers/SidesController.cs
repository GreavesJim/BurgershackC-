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
  public class SidesController : ControllerBase
  {
    private readonly SidesServices _ss;
    public SidesController(SidesServices ss)
    {
      _ss = ss;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Side>> Get()
    {
      try
      {
        return Ok(_ss.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Side> Get(int id)
    {
      try
      {
        return Ok(_ss.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{Id}")]
    public ActionResult<Side> Edit(int id, [FromBody]Side update)
    {
      try
      {
        update.Id = id;
        return Ok(_ss.Edit(update));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Side> Create([FromBody] Side newItem)
    {
      try
      {
        return Ok(_ss.Create(newItem));
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
        return Ok(_ss.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}