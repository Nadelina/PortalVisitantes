using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalVisitantes.API.Commands.Visitante;
using PortalVisitantes.DATA.Data.Entities;
using PortalVisitantes.DATA.Repositories.Interfaces;

namespace PortalVisitantes.API.Handlers
{
    public class VisitanteHandler
    {
        private readonly IVisitantesRepository _visitantesRepository;
        private readonly IMapper _mapper;

        public VisitanteHandler(IVisitantesRepository visitantesRepository, IMapper mapper)
        {
            _visitantesRepository = visitantesRepository;
            _mapper = mapper;
        }

        public async Task<List<Visitantes>> ObtenerListado()
        {
            return await EvaluarListado();
        }
        public async Task CrearVisitaAsync(CrearVisitanteCommand command)
        {
            var visitante = new Visitantes
            {
                Dui = command.Dui,
                Nombre = command.Nombre,
                FechaNacimiento = command.FechaNacimiento,
                Email = command.Email,
                Telefono = command.Telefono
            };

            await _visitantesRepository.CreateAsync(visitante);
        }

        public async Task<List<Visitantes>> EvaluarListado()
        {
            var visitantes = _visitantesRepository.GetAll().Where(v => string.IsNullOrEmpty(v.Generacion)).ToList();

            foreach (var visitante in visitantes)
            {
                visitante.Generacion = DeterminarGeneracion(visitante.FechaNacimiento);
                await _visitantesRepository.UpdateAsync(visitante);
            }
            return(visitantes);
        }

        public static string DeterminarGeneracion(DateTime fechaNacimiento)
        {
            if (fechaNacimiento.Year >= 1949 && fechaNacimiento.Year <= 1968)
            {
                return "Baby Boomer";
            }
            else if (fechaNacimiento.Year >= 1969 && fechaNacimiento.Year <= 1980)
            {
                return "Generación X";
            }
            else if (fechaNacimiento.Year >= 1981 && fechaNacimiento.Year <= 1993)
            {
                return "Millennial";
            }
            else if (fechaNacimiento.Year >= 1994 && fechaNacimiento.Year <= 2010)
            {
                return "Generación Z";
            }
            else if (fechaNacimiento.Year > 2010)
            {
                return "Generación Alpha";
            }
            else
            {
                return "Desconocida";
            }
        }
    }
}
