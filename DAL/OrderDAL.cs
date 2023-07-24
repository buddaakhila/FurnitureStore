using FurnitureStore.Model;
using FurnitureStore.Model1;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.SqlClient;

namespace FurnitureStore.DAL;


public class OrderDAL
{
    public List<Allorder> getAllOrders(int id) 
    {
        
        FurnitureStoreDbContext1 dbcontext = new FurnitureStoreDbContext1();
        var model = dbcontext.Allorders.Where(i => i.Customerid == id).ToList();
        return model;  
    }
    public void neworder(Order1 order)
    {
        FurnitureStoreDbContext dbContext = new FurnitureStoreDbContext();
        dbContext.Database.ExecuteSqlRaw($"EXEC AddFurnitureToOrder {order.FurnitureName},{order.Price},{order.FurnitureId},{order.CustomerId}");
    }

 

    public void updateorder(UpdateOrder order)
    {
        FurnitureStoreDbContext dbContext = new FurnitureStoreDbContext();
        dbContext.Database.ExecuteSqlRaw($"EXEC UpdateOrderQuantity {order.OrderId},{order.Quantity}");
    }
}