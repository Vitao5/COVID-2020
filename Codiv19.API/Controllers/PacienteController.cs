using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Codiv19.API.Models;
using Codiv19.API.Repositories;
using Codiv19.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codiv19.API.Controllers
{
    [Authorize(Roles = "administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(
            IPacienteService pacienteService
        ) {
            _pacienteService = pacienteService;
        }
        //private readonly PacienteRepository pacienteRepository;

        //public PacienteController()
        //{
        //    pacienteRepository = new PacienteRepository();
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pacientes = _pacienteService.PegarTodos();
            return Ok(pacientes);
            //return Ok("lista de todos os pacientes");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var paciente = _pacienteService.GetOne(id);
            return Ok(paciente);
            //return Ok("dados do paciente específico");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Paciente paciente)
        {
            _pacienteService.Create(paciente);
            //pacienteRepository.novoPaciente(paciente);
            return Ok("paciente cadastrado ");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Paciente paciente)
        {
            _pacienteService.Update(paciente);
            //Paciente p = new Paciente();
            return Ok("paciente foi atualizado");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int  id)
        {
            _pacienteService.Delete(id);
            return Ok("paciente foi deleteado");
        }

    }
}
