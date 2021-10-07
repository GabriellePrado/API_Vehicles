using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_API_Vehicles.Data.Configuration;
using Teste_API_Vehicles.Data.Repositories;
using Teste_API_Vehicles.Models;

namespace Teste_API_Vehicles.Data
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IMongoCollection<Vehicle> _vehicles;

        public VehicleRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _vehicles = database.GetCollection<Vehicle>("Vehicle");
        }

        public void Create(Vehicle vehicle)
        {
            _vehicles.InsertOne(vehicle);
        }
        public void Update( Vehicle vehicleUpdate)
        {
           
            _vehicles.ReplaceOne(vehicle => vehicle.Id == vehicleUpdate.Id, vehicleUpdate);
        }
        public void Delete(int id)
        {
            _vehicles.DeleteOne(vehicle => vehicle.Id == id);
        }

        public IEnumerable<Vehicle> ListVehicle()
        {
            return _vehicles.Find(vehicle => true).ToList();
        }

        public Vehicle SearchVehicle(int id)
        {
            return _vehicles.Find(vehicle => vehicle.Id == id).FirstOrDefault();
        }

    }
}
