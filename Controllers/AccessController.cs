using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Controllers;
using FurnitureStore.Model;
using FurnitureStore.DAL;
namespace FurnitureStore.Controllers;

[ApiController]
[Route("[controller]/[action]")]

public class AdminController : ControllerBase
{
    
    [HttpGet]
    public IActionResult validateAdmin(string admin,string password)
    {
        FurnitureImplementation adminModel = new FurnitureImplementation();
        var ops = adminModel.getAdmin(1);
        if(ops[0]==admin && ops[1]==password)
        {
            var m1 = new Admin()
            {
                AdminId = 1,
                Username = admin,
                Password = password
            };
            return new JsonResult(m1);
        }
        return Ok("Login Failure");
    }
    [HttpGet]
    public IActionResult validateCustomer(string user,string password)
    {
        FurnitureImplementation customerModel = new FurnitureImplementation();
        var ops = customerModel.getCustomer(user);
        if(ops.Count() >0)
        {
        if(ops[0]==user && ops[1]==password)
        {
            return Ok("Logged in successfully");

        }
        }
        return Ok("Login Failure");
        
    }
}