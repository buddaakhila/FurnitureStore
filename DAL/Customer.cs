using FurnitureStore.Model;
using Microsoft.EntityFrameworkCore;
namespace FurnitureStore.DAL;

public class Customer
{
    public void createcustomer(CustomerMaster1 customer)
    {
        FurnitureStoreDbContext dbContext = new FurnitureStoreDbContext();
        dbContext.Database.ExecuteSqlRaw($"EXEC CreateCustomer {customer.Username},{customer.Password},{customer.Displayname},{customer.PhoneNumber},{customer.Address}");
        var cust = dbContext.CustomerMasters.ToList();

    }

    public void deletecustomer(string username)
    {
        FurnitureStoreDbContext dbContext = new FurnitureStoreDbContext();
        dbContext.Database.ExecuteSqlRaw($"EXEC deleteuser {username}");
        var r = dbContext.CustomerMasters.ToList();
    }
}