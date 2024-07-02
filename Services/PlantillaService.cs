using NetCorePlantillas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiPlantillas.Interfaces;

namespace WebApiPlantillas.Services
{
    public interface IPlantillaService
    {
        Task<List<Plantilla>> GetPlantillas();
        Task<Plantilla> GetPlantillaById(int id);
        Task CrearPlantilla(Plantilla plantilla);
        Task ActualizarPlantilla(Plantilla plantilla);
        Task EliminarPlantilla(int id);
    }

    public class PlantillaService : IPlantillaService
    {
        private readonly IPlantillaRepository _plantillaRepository;

        public PlantillaService(IPlantillaRepository plantillaRepository)
        {
            _plantillaRepository = plantillaRepository;
        }

        public async Task<List<Plantilla>> GetPlantillas()
        {
            return await _plantillaRepository.GetPlantillas();
        }

        public async Task<Plantilla> GetPlantillaById(int id)
        {
            return await _plantillaRepository.GetPlantillaById(id);
        }

        public async Task CrearPlantilla(Plantilla plantilla)
        {
            await _plantillaRepository.CrearPlantilla(plantilla);
        }

        public async Task ActualizarPlantilla(Plantilla plantilla)
        {
            await _plantillaRepository.ActualizarPlantilla(plantilla);
        }

        public async Task EliminarPlantilla(int id)
        {
            await _plantillaRepository.EliminarPlantilla(id);
        }
    }
}
