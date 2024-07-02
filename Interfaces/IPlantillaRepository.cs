    using NetCorePlantillas.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApiPlantillas;


namespace WebApiPlantillas.Interfaces
{
    public interface IPlantillaRepository
    {
        Task<List<Plantilla>> GetPlantillas();
        Task<Plantilla> GetPlantillaById(int id);
        Task CrearPlantilla(Plantilla plantilla);
        Task ActualizarPlantilla(Plantilla plantilla);
        Task EliminarPlantilla(int id);
    }
}
