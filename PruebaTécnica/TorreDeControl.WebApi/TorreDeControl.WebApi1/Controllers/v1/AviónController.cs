using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TorreDeControl.Core.Application.Interfaces.IServices;
using TorreDeControl.Core.Application.ViewModels.Aeropuerto;
using TorreDeControl.Core.Application.ViewModels.Avión;

namespace TorreDeControl.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AviónController : BaseApiController
    {
        private readonly IAviónService _aviónService;

        public AviónController(IAviónService aviónService)
        {
            _aviónService = aviónService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AviónViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _aviónService.GetAllViewModelWithInclude();

                if (products == null || products.Count == 0)
                {
                    return NotFound();
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveAviónViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var product = await _aviónService.GetByIdSaveViewModel(id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Policy = "CustomPolicy")]
        public async Task<IActionResult> Post(SaveAviónViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                // Asignar el valor predeterminado al estado del avión
                vm.estadoDelAvión = "aun no sale del aeropuerto";
                IniciarProcesoActualizacion(); // Inicia el proceso periódico de actualización de estados
                await _aviónService.Add(vm);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveAviónViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, SaveAviónViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _aviónService.Update(vm, id);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aviónService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        #region Autorización
        public class CustomAuthorizationHandler : AuthorizationHandler<CustomRequirement>
        {
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomRequirement requirement)
            {
                // Obtiene la información necesaria para realizar la verificación
                var avión = context.Resource as SaveAviónViewModel;
                if (context.Resource is SaveAviónViewModel)
                {
                    // Realiza la verificación
                    if (avión.horaDeLlegada != avión.horaDeSalida)
                    {
                        context.Succeed(requirement);
                    }
                    else
                    {
                        context.Fail();
                    }
                }
                else
                {
                    context.Fail();
                }

                return Task.CompletedTask;
            }
        }
        #endregion

        // Método para actualizar los estados de los aviones
        private async void ActualizarEstadosAviones(Task<List<SaveAviónViewModel>> aviones)
        {
            var listaAviones = await _aviónService.GetAllViewModel();

            foreach (var avion in listaAviones)
            {
                var horaActual = DateTime.Now;

                if (horaActual >= avion.horaDeSalida && horaActual < avion.horaDeLlegada)
                {
                    avion.estadoDelAvión = "sigue en vuelo";
                }
                else if (horaActual >= avion.horaDeLlegada)
                {
                    avion.estadoDelAvión = "el avión ya aterrizó";
                }
                var avionToUpdate = new SaveAviónViewModel
                {
                    estadoDelAvión = avion.estadoDelAvión,
                };
                int id = avion.idAvión;
                await _aviónService.Update(avionToUpdate, id); // Método para actualizar el estado del avión en tu servicio
            }
        }

        // Método para iniciar el proceso periódico de actualización
        private void IniciarProcesoActualizacion()
        {
            var temporizador = new Timer(state =>
            {
                ActualizarEstadosAviones(null);
            }, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
        }
    }
}
