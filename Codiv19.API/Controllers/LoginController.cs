﻿using Codiv19.API.Models;
using Codiv19.API.Repositories;
using Codiv19.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codiv19.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginRepository _repository;
        public LoginController()
        {
            _repository = new LoginRepository();
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("autenticacao")]
        public async Task<ActionResult<dynamic>> autenticacao(Login login)
        {
            var usuario = _repository.GetLogin(login);
            if (usuario == null)
                return NotFound(" usuário inválido, verifique os dados digitados");


            var token = TokenService.GenerateToken(usuario);
            login.senha = "";
            return new
            {
                usuario = usuario,
                token = token
            };
        }
    }
}
