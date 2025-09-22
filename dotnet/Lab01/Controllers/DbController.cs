using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
namespace Lab01.Controllers;

[ApiController]
[Route("users")]
public class DbController : ControllerBase
{
    private readonly MySqlConnection _connection;
    public DbController(MySqlConnection connection)
    {
        _connection = connection;
    }
    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = new List<object>();
        try
        {
            _connection.Open();
            using var cmd = new MySqlCommand("SELECT id, name, age FROM users", _connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Age = reader.GetInt32("age")
                });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
        finally
        {
            _connection.Close();
        }
        return Ok(users);
    }
}