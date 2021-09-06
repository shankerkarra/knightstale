using System;
using System.Collections.Generic;
using knightstale.Models;
using knightstale.Repositories;
namespace knightstale.Services
{
  public class KnightService
  {
    private readonly KnightsRepository _repo;

    public KnightService(KnightsRepository repo)
    {
      _repo = repo;
    }

    internal List<Knight> Get()
    {
      return _repo.Get();
    }

    internal Knight Get(int id)
    {
      Knight evt = _repo.Get(id);
      if (evt == null)
      {
        throw new Exception("Invalid Id");
      }
      return evt;
    }


    internal Knight Create(Knight newKnight)
    {
      return _repo.Create(newKnight);
    }

    internal void Delete(int id)
    {
      _repo.Delete(id);
    }
  }
}