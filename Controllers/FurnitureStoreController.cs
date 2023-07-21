using Microsoft.AspNetCore.Mvc;
using FurnitureStore.Bll;
namespace FurnitureStore.Controllers;

[ApiController]
[Route("[controller]")]
public class FurnitureStoreController : ControllerBase
{
    FurnitureStoreBll bll = new FurnitureStoreBll();

    [HttpPost("/adminlogin")]
    public ActionResult AdminLogin([FromHeader] string Username, [FromHeader] string Password)
    {
        bool authorize = bll.validateadmin(Username, Password);
        if (authorize)
        {
            // --------add product page link---------------
            return Ok("Next Page link here");
        }
        else
        {
            return Unauthorized("Insufficient Privileges");
        }

    }

}