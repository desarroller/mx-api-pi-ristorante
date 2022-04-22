using StorageDB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PosService.Services
{
    public class StorageDBService
    {
        private readonly IMongoCollection<Products> _productsCollection;

        public StorageDBService(IOptions<StorageDBSettings> storegeDBSettings)
        {
            var mongoClient = new MongoClient(
                storegeDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                storegeDBSettings.Value.DatabaseName);

            _productsCollection = mongoDatabase.GetCollection<Products>
                (storegeDBSettings.Value.ProductsCollectionName);
        }

        public async Task<List<Products>> GetAsync() =>
               await _productsCollection.Find(_ => true).ToListAsync();

        public async Task<Products?> GetAsync(string id) =>
               await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        
        public async Task CreateAsync(Products newProduct) =>
               await _productsCollection.InsertOneAsync(newProduct);

        public async Task UpdateAsync(string id, Products updatedProduct) =>
               await _productsCollection.ReplaceOneAsync(x => x.Id == id, updatedProduct);

        public async Task RemoveAsync(string id) =>
            await _productsCollection.DeleteOneAsync(x => x.Id == id);

    }
}
