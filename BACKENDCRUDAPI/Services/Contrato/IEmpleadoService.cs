using BACKENDCRUDAPI.Models;

namespace BACKENDCRUDAPI.Services.Contrato
{
    public interface IEmpleadoService
    {

        Task<List<Empleado>> GetList();
        Task<Empleado> Get(int IDEMPLEADO);
        Task<Empleado> Add(Empleado modelo);
        Task<bool> Update(Empleado modelo);
        Task<bool> Delete(Empleado modelo);
    }
}
