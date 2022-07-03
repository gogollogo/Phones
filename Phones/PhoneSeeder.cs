using Phones.Entities;

namespace Phones;
public class PhoneSeeder
{
    private readonly PhonesDbContext _dbContext;

    public PhoneSeeder(PhonesDbContext dbContext)
    {

        _dbContext = dbContext;
    }
    public void Seed()
    {
        if (_dbContext.Database.CanConnect())
        {
            if (!_dbContext.Phones.Any())
            {
                var phones = GetPhones();
                _dbContext.Phones.AddRange(phones);
                _dbContext.SaveChanges();
            }
            if(!_dbContext.Roles.Any())
            {
                var roles = GetRoles();
                _dbContext.Roles.AddRange(roles);
                _dbContext.SaveChanges();
            }
        }
    }

    private IEnumerable<Phone> GetPhones()
    {
        var phones = new List<Phone>()
        {
            new Phone()
            {
                Name = "Iphone",
                Price = 12.00M,
                Brand = new Brand()
                {
                    Name = "Apple"
                }
            },
            new Phone()
            {
                Name = "Galaxy",
                Price = 10.00M,
                Brand = new Brand()
                {
                    Name = "Samsung"
                }
            }

         };
        return phones;
    }
    private IEnumerable<Role> GetRoles()
    {
        var roles = new List<Role>()
        {
            new Role
            {
                Name = "SimpleUser",
              
            },
            new Role
            {
                Name = "Admin",
            }

         };
        return roles;
    }
}