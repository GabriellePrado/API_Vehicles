using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Teste_API_Vehicles.Business.Service.IVehicleService;
using Teste_API_Vehicles.Data.Configuration;
using Teste_API_Vehicles.Data.Repositories;
using Teste_API_Vehicles.Models;

namespace API_Vehicles.Business.Service
{
    public class VehicleService : IVehicleService
    { // controller chama este servico que por sua vez chama repositorio 
      //controller - servico - repositorio 

        private readonly IVehicleRepository _repository;
        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public void Create(Vehicle vehicle)
        {
            _repository.Create(vehicle);
        }
        public void Update(Vehicle vehicleUpdate)
        {
            _repository.Update(vehicleUpdate);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Vehicle> ListVehicle()
        {
            return _repository.ListVehicle();
        }

        public Vehicle SearchVehicle(int id)
        {
            return _repository.SearchVehicle(id);
        }

    }
}
