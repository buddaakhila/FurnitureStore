using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Controllers;
using FurnitureStore.Model;
using FurnitureStore.DAL;
namespace FurnitureStore.Controllers;

[ApiController]
[Route("[controller]/[action]")]

public class FurnitureController : ControllerBase
{
    [HttpPut]
    public ActionResult inactivefurniture(int furnitureid)
    {
        Furniture dbContext = new Furniture();
        dbContext.inactivatefurniture(furnitureid);
        return Ok();
    }
}