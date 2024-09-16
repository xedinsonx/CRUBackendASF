using Microsoft.EntityFrameworkCore;
using BACKENDCRUDAPI.Models;
using BACKENDCRUDAPI.Services.Contrato;

namespace BACKENDCRUDAPI.Services.Implementacion
{
    public class CargoService : ICargoService
    {
        private EmpleadoasfContext _dbcontext;

        public CargoService(EmpleadoasfContext dbcontext) 
        { 
            _dbcontext = dbcontext;
        }

        public async Task<List<Cargo>> GetList()
        {
            try
            {
                List<Cargo>lista = new List<Cargo>();
                lista=await _dbcontext.Cargos.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
