using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Controllers;
using FurnitureStore.Model;
using FurnitureStore.DAL;
namespace FurnitureStore.Controllers;

[ApiController]
[Route("[controller]/[action]")]

public class BillingController : ControllerBase
{
    [HttpPost]
    public ActionResult CreateBillinng(int id)
    {
        Billing b = new Billing();
        BillingModel billing1 = new BillingModel();
        b.createbilling(billing1,id);
        return Ok();
    }
}