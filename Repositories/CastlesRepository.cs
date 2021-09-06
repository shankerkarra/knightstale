using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using knightstale.Models;
namespace knightstale.Repositories
{
  public class CastlesRepository
  {
    private readonly IDbConnection _db;
    public CastlesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Castle> Get()
    {
      string sql = @"
      SELECT 
       c.*
      FROM Castle c
       ";
      return _db.Query<Castle>(sql, (Castle));

    }

    internal Castle Get(int id)
    {
      string sql = @"
      SELECT 
       c.*
      FROM Castle c
      JOIN Knights k ON k.castleId = c.id
      WHERE c.id = @id
      ";
      // data type 1, data type 2, return type
      return _db.Query<Knight, Castle, Castle>(sql, (knights, Castle) =>
      {
        Castle.id = knights.castleid;
        return Castle;
      }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal Castle Create(Castle newCastle)
    {
      string sql = @"
        INSERT INTO castle
        (name, location)
        VALUES
        (@Name, @Location);
        SELECT LAST_INSERT_ID();
        ";
      int id = _db.ExecuteScalar<int>(sql, newCastle);
      return Get(id);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM castle WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}