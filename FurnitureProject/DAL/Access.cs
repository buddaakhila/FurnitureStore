using FurnitureStore.Model;
namespace FurnitureStore.DAL;

public class FurnitureImplementation
{
    public List<string> getAdmin(int id)
    {
        List<string> adminList = new List<string>();
        using(FurnitureStoreDbContext context = new FurnitureStoreDbContext())
        {
            
            var name = context.Admins.Where(a => a.AdminId == id).FirstOrDefault().Username;
            var pass = context.Admins.Where(a => a.AdminId == id).FirstOrDefault().Password;
            adminList.Add(name);
            adminList.Add(pass);
        }
        return adminList;
    }

    public List<string> getCustomer(string name)
    {
        List<string> customerList = new List<string>();
        using(FurnitureStoreDbContext context = new FurnitureStoreDbContext())
        {
            try{
            var uname = context.CustomerMasters.Where(a => a.Username == name).FirstOrDefault().Username;
            var pass = context.CustomerMasters.Where(a => a.Username == name).FirstOrDefault().Password;
            customerList.Add(uname);
            customerList.Add(pass);
            return customerList;
            }
            catch(Exception e)
            {
                return customerList;
            }
        }
        
    }
}