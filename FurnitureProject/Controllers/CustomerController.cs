using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Controllers;
using FurnitureStore.Model;
using FurnitureStore.DAL;
namespace FurnitureStore.Controllers;

[ApiController]
[Route("[controller]/[action]")]

public class CustomerController : ControllerBase
{
    [HttpPost]
    public ActionResult CreateCustomer([FromBody]CustomerMaster1 customer)
    {
        
            Customer c = new Customer();
            c.createcustomer(customer);
            return Ok();
        
    }
}