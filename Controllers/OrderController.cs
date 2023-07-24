using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Controllers;
using FurnitureStore.Model;
using FurnitureStore.Model1;
using FurnitureStore.DAL;
namespace FurnitureStore.Controllers;

[ApiController]
[Route("[controller]/[action]")]

public class OrderController : ControllerBase
{
    [HttpGet]
    public JsonResult getOrders(int custid)
    {
        OrderDAL order1 = new OrderDAL();
        var op = order1.getAllOrders(custid);
        List<object> result = new List<object>();
        
        foreach (var item in op)
        {
            var response = new Allorder
            {
                Orderid = item.Orderid,
                Quantity = item.Quantity,
                FurnitureName = item.FurnitureName,
                Price = item.Price,
                Customerid = item.Customerid
            };
            result.Add(response);
        }
        return new JsonResult(result);
        
    }

    [HttpPost("/addtocart")]
    public ActionResult Createneworder([FromBody]Order1 order)
    {
        OrderDAL bll = new OrderDAL();
        try
        {
            bll.neworder(order);
            return Ok();
        }
        catch
        {
            return Unauthorized("Insufficient Privileges");
        }

 

    }

 

    [HttpPost("/updateorder")]
    public ActionResult Updateorder([FromBody]UpdateOrder order)
    {
        OrderDAL bll = new OrderDAL();
        try
        {
            bll.updateorder(order);
            return Ok();
        }
        catch
        {
            return Unauthorized("Insufficient Privileges");
        }

 

    }
}