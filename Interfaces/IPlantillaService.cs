using NetCorePlantillas.Models;

namespace WebApiPlantillas.Interfaces
{
    public interface IPlantillaService
    {
        IEnumerable<Plantilla> GetPlantillas();
        Plantilla GetPlantillaById(int id);
        Plantilla CrearPlantilla(Plantilla plantilla);
        void ActualizarPlantilla(Plantilla plantilla);
        void EliminarPlantilla(int id);
    }
}
