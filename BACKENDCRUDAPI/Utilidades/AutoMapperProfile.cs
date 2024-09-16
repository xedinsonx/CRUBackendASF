using AutoMapper;
using BACKENDCRUDAPI.DTOs;
using BACKENDCRUDAPI.Models;
using System.Globalization;


namespace BACKENDCRUDAPI.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            #region Cargo
            CreateMap<Cargo, CargoDTO>().ReverseMap();
            #endregion

            #region Empleado
            CreateMap<Empleado, EmpleadoDTO>()
                .ForMember(destino => destino.NombreCargo,
                opt => opt.MapFrom(origen => origen.IdcargoNavigation.Nombre)
                )
                .ForMember(destino => destino.FechaNacimiento,
                opt => opt.MapFrom(origen => origen.FechaNacimiento.ToString("dd/MM/yyyy"))
                )
                .ForMember(destino => destino.FechaIngreso,
                opt => opt.MapFrom(origen => origen.FechaIngreso.ToString("dd/MM/yyyy"))
                );

            CreateMap<EmpleadoDTO, Empleado>()
            .ForMember(destino => destino.IdcargoNavigation,
            opt => opt.Ignore()
            )
            .ForMember(destino =>
            destino.FechaNacimiento,
            opt => opt.MapFrom(origen => DateTime.ParseExact(origen.FechaNacimiento, "dd/mm/yyyy", CultureInfo.InvariantCulture))
            );
            #endregion
        }
    }
}
