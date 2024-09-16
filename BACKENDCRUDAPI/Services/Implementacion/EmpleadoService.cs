using BACKENDCRUDAPI.Models;
using BACKENDCRUDAPI.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BACKENDCRUDAPI.Services.Implementacion
{
    public class EmpleadoService : IEmpleadoService
    {
        private EmpleadoasfContext _dbcontext;

        public EmpleadoService(EmpleadoasfContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Empleado>> GetList()
        {
            try
            {
                List<Empleado> lista = new List<Empleado>();
                lista = await _dbcontext.Empleados.Include(dpt =>dpt.IdcargoNavigation).ToListAsync();

                return lista;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Empleado> Get(int IDEMPLEADO)
        {
            try
            {
                Empleado? encontrado = new Empleado();

                encontrado = await _dbcontext.Empleados.Include(dpt => dpt.IdcargoNavigation)
                    .Where(e => e.Idempleado == IDEMPLEADO).FirstOrDefaultAsync();
                return encontrado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task<Empleado> Add(Empleado modelo)
        {
            try
            {
                _dbcontext.Empleados.Add(modelo);
                await _dbcontext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            }
          
        public async Task<bool> Update(Empleado modelo)
            {
        try
        {
            _dbcontext.Empleados.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        catch(Exception ex)
        {
            throw ex;
        }
        }
        
        public async Task<bool> Delete(Empleado modelo)
        {
            try
        {
                _dbcontext.Empleados.Remove(modelo);
                await _dbcontext.SaveChangesAsync();
                return true;
        }
            catch(Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
