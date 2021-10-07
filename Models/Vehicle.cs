using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_API_Vehicles.Models
{
    public class Vehicle
    {

        
        public int Id { get; set; }
        public int NumeroPassageiros { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
        public bool IsCambioAutomatico  { get; set; }

        public Vehicle(int id, int numeroPassageiros, string cor, string marca, bool IsCambioAutomatico)
        {
            Id = id;
            NumeroPassageiros = numeroPassageiros;
            Cor = cor;
            Marca = marca;
            if(IsCambioAutomatico == null) { 
            IsCambioAutomatico = false;
                }
        }
    }
}
