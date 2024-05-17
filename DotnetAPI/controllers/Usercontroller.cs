using DotnetAPI.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace DotnetAPI.contollers;
[ApiController]
[Route("controller")]
public class Usercontroller: ControllerBase
{
    dataContextDapper _dapper;
    public Usercontroller(IConfiguration configuration)
    {
      _dapper= new dataContextDapper(configuration);
    }
    [HttpGet("Userdetails/{ID}")]
    public User Userdetails(int ID)
{
    string sql = @"SELECT [userId], [Firstname], [Lastname], [PASSWORD]
                   FROM [Company].[users]
                   WHERE userId = " + ID.ToString();
    User user = _dapper.Loadingdatasingle(sql);
    return user;
}

[HttpGet("Test/{name}")]
   public string[] Test(string name){
    string[] strings= { "Sulakshana", "Anjani"};
    Array.Resize(ref strings, strings.Length + 1);
        strings[strings.Length - 1] = name;
   
    return strings;
      }
[HttpGet("add")]
public IActionResult AddUser([FromBody] User newUser)
{
    try
    { string sql=$@"
            INSERT INTO [Company].[users] ([userID],[Firstname], [Lastname], [PASSWORD])
            VALUES ('{newUser.userId}','{newUser.Firstname}', '{newUser.Lastname}', '{newUser.PASSWORD}')";
           Console.WriteLine(sql);
        // Execute SQL query to add user
        int rowsAffected = _dapper.Executesql($@"
            INSERT INTO [Company].[users] ([userID],[Firstname], [Lastname], [PASSWORD])
            VALUES ('{newUser.userId}','{newUser.Firstname}', '{newUser.Lastname}', '{newUser.PASSWORD}')");
            


        // Check if user was successfully added
        if (rowsAffected > 0)
        {
            // Return 201 Created response with success message
            return StatusCode(201, "User added successfully");
        }
        else
        {
            // Return 500 Internal Server Error response with error message
            return StatusCode(500, "Failed to add user");
        }
    }
    catch (Exception ex)
    {
        // Return 500 Internal Server Error response with error message
        return StatusCode(500, $"An error occurred: {ex.Message}");
    }
}


        [HttpPut("edit/{userId}")]
public IActionResult EditUser(int userId, [FromBody] User updatedUser)
{
    try
    {
        // Execute SQL query to edit user
        int rowsAffected = _dapper.Executesql($@"
            UPDATE [Company].[users]
            SET [Firstname] = '{updatedUser.Firstname}',
                [Lastname] = '{updatedUser.Lastname}',
                [PASSWORD] = '{updatedUser.PASSWORD}'
            WHERE [userId] = {userId}");

        // Check if user was successfully updated
        if (rowsAffected > 0)
        {
            // Return 200 OK response with success message
            return Ok("User updated successfully");
        }
        else
        {
            // Return 404 Not Found response with error message if user not found
            return NotFound("User not found");
        }
    }
    catch (Exception ex)
    {
        // Return 500 Internal Server Error response with error message
        return StatusCode(500, $"An error occurred: {ex.Message}");
    }
}

    }

