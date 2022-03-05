namespace SuggestionAppLibrary.DataAccess
{
    public class MongoUserData : IUserData
    {
        private readonly IMongoCollection<UserModel> _user;

        public MongoUserData(IDbConnection db)
        {
            _user = db.UserCollection;
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            var results = await _user.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<UserModel> GetUser(string id)
        {
            var result = await _user.FindAsync(u => u.Id == id);
            return result.FirstOrDefault();
        }

        public async Task<UserModel> GetUserByAuthentication(string objectId)
        {
            var result = await _user.FindAsync(u => u.ObjectIdentifier == objectId);
            return result.FirstOrDefault();
        }

        public Task CreateUser(UserModel user)
        {
            return _user.InsertOneAsync(user);
        }

        public Task UpdateUser(UserModel user)
        {
            var filter = Builders<UserModel>.Filter.Eq("Id", user.Id);
            return _user.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
        }
    }
}
