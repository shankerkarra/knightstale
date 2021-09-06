using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using knightstale.Models;
using knightstale.Services;
namespace knightstale.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class CastleController : ControllerBase
  {
    private readonly CastleService _castleService;

    public CastleController(CastleService castleService)
    {
      _castleService = castleService;
    }

    [HttpGet]
    public ActionResult<List<Castle>> Get()
    {
      try
      {
        List<Castle> events = _castleService.Get();
        return Ok(events);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpGet("{id}")]
    public ActionResult<Castle> Get(int id)
    {
      try
      {
        Castle evt = _castleService.Get(id);
        return Ok(evt);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    [Authorize]
    // NOTE Task allows us to use async/await
    public ActionResult<Castle> Create([FromBody] Castle newCastle)
    {
      try
      {
        return (_castleService.Create(newCastle));
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        _castleService.Delete(id);
        return Ok("Delorted");
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }

}