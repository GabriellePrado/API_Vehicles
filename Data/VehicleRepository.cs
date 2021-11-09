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
            try
            {
                _vehicles.InsertOne(vehicle);
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao criar um novo veiculo " + e.Message);
            }
        }
        public void Update( Vehicle vehicleUpdate)
        {
            try
            {
                _vehicles.ReplaceOne(vehicle => vehicle.Id == vehicleUpdate.Id, vehicleUpdate);
            }
            catch (Exception e)
            {
                throw new Exception("Erro atualizar " + e.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                _vehicles.DeleteOne(vehicle => vehicle.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao deletar " + e.Message);
            }
        }

        public IEnumerable<Vehicle> ListVehicle()
        {
            try
            {
                return _vehicles.Find(vehicle => true).ToList(); 
            }
            catch (Exception e)
            {
                throw new Exception("Não encontrado " + e.Message);
            }
        }

        public Vehicle SearchVehicle(int id)
        {
            try
            {
                return _vehicles.Find(vehicle => vehicle.Id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("Erro: " + e.Message);
            }
        }

    }
}
