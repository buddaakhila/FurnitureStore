using FurnitureStore.Model;
using Microsoft.EntityFrameworkCore;
namespace FurnitureStore.DAL;

public class Billing
{
    public void createbilling(BillingModel bill,int id)
    {
        FurnitureStoreDbContext dbContext = new FurnitureStoreDbContext();
        dbContext.Database.ExecuteSqlRaw($"EXEC AddBilling {id}");
    }
}