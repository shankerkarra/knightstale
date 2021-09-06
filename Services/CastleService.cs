using System;
using System.Collections.Generic;
using knightstale.Models;
using knightstale.Repositories;
namespace knightstale.Services
{
  public class CastleService
  {
    private readonly CastlesRepository _repo;

    public CastleService(CastlesRepository repo)
    {
      _repo = repo;
    }

    internal List<Castle> Get()
    {
      return _repo.Get();
    }

    internal Castle Get(int id)
    {
      Castle evt = _repo.Get(id);
      if (evt == null)
      {
        throw new Exception("Invalid Id");
      }
      return evt;
    }


    internal Castle Create(Castle newCastle)
    {
      return _repo.Create(newCastle);
    }

    internal void Delete(int id)
    {
      _repo.Delete(id);
    }
  }
}