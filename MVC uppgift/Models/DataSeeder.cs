using MVC_uppgift.Data;

namespace MVC_uppgift.Models
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _db;
        public DataSeeder(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Seed()
        {
            if (!_db.Peoples.Any())
            {
                List<People> P = new()
                {
                    new People {  Name = "Mickey Mouse", PhoneNumber = 1234235, City = "Disneyland" },
                    new People {  Name = "Tony montana", PhoneNumber = 24523421, City = "Cuba" },
                    new People {  Name = "Lu Xiojun", PhoneNumber = 5663352, City = "China" }
                };
                _db.Peoples.AddRange(P);
                _db.SaveChanges();
            }
        }
    }
}
