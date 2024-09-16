
using BACKENDCRUDAPI.Models;

namespace BACKENDCRUDAPI.Services.Contrato
{
    public interface ICargoService
    {
        Task<List<Cargo>> GetList();
    }
}
