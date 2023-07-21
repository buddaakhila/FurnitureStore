using FurnitureStore.Models;
namespace FurnitureStore.Bll;

public class FurnitureStoreBll
{

    // --------------------Change connection string------------------------
    string connectionString = "Server=.;Database=FurnitureStoreDB;Trusted_Connection=True;";
    public bool validateadmin(string Username, string Password)
    {
        Console.WriteLine(Username);
        Console.WriteLine(Password);
        using (FurnitureStoreDbContext context = new FurnitureStoreDbContext())
        {
            string a=null;
            a = context.Admins.Where(x => x.Username == Username).FirstOrDefault()?.Password;
            Console.WriteLine(a);
            if (a != null)
            {
                if (a == Password)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
    
}