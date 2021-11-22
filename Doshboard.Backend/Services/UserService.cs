namespace Doshboard.Backend.Services
{
    public class UserService
    {
        private Mongo _db;
        public UserService(Mongo db)
        {
            db = _db;
        }
    }
}
