using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_API_Vehicles.Data;
using Teste_API_Vehicles.Data.Repositories;
using Teste_API_Vehicles.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste_API_Vehicles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_vehicleRepository.ListVehicle().ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id == null || id == 0)
            {
                NotFound();
            }

            return Ok(_vehicleRepository.SearchVehicle(id));
        }

        [HttpPost]
        public void Create([FromBody] Vehicle vehicle)
        {
            _vehicleRepository.Create(vehicle);
        }

        [HttpPut("{id}")]
        public void Update([FromBody] Vehicle vehicle)
        {
            _vehicleRepository.Update(vehicle);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id == null || id == 0)
            {
                NotFound();
            }

            _vehicleRepository.Delete(id);
        }
    }
}
