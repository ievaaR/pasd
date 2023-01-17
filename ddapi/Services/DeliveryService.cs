using ddapi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ddapi.Services;

public class DeliveryService {
   private readonly IMongoCollection<Delivery> _deliveriesCollection;

   public DeliveryService(IOptions<DatabaseSettings> databaseSettings) {
      var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
      var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
      _deliveriesCollection = mongoDatabase.GetCollection<Delivery>(databaseSettings.Value.CollectionName);
   }

   public async Task<List<Delivery>> GetAsync() =>
        await _deliveriesCollection.Find(_songsCollection => true).ToListAsync();
   
   public async Task CreateAsync(Delivery newSong) =>
        await _deliveriesCollection.InsertOneAsync(newSong);
}