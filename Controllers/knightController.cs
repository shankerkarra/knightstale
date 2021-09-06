using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using knightstale.Models;
using knightstale.Services;
namespace Knightstale.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class KnightController : ControllerBase
  {
    private readonly KnightService _knightService;

    public KnightController(KnightService KnightService)
    {
      _knightService = KnightService;
    }

    [HttpGet]
    public ActionResult<List<Knight>> Get()
    {
      try
      {
        List<Knight> events = _knightService.Get();
        return Ok(events);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpGet("{id}")]
    public ActionResult<Knight> Get(int id)
    {
      try
      {
        Knight evt = _knightService.Get(id);
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
    public ActionResult<Knight> Create([FromBody] Knight newKnight)
    {
      try
      {
        return (_knightService.Create(newKnight));
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
        _knightService.Delete(id);
        return Ok("Delorted");
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }

}