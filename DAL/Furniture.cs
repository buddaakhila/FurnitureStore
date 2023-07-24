using FurnitureStore.Model;
using Microsoft.EntityFrameworkCore;
namespace FurnitureStore.DAL;

public class Furniture
{
    public void inactivatefurniture(int id)
    {
        FurnitureStoreDbContext dbContext = new FurnitureStoreDbContext();
        dbContext.Database.ExecuteSqlRaw($"EXEC inactivateproduct {id}");
        var r = dbContext.FurnitureMasters.ToList();
    }
}