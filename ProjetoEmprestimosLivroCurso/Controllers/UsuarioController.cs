﻿using Microsoft.AspNetCore.Mvc;
using ProjetoEmprestimosLivroCurso.Dto.Usuario;
using ProjetoEmprestimosLivroCurso.Enums;
using ProjetoEmprestimosLivroCurso.Models;
using ProjetoEmprestimosLivroCurso.Services.UsuarioService;

namespace ProjetoEmprestimosLivroCurso.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        public async Task<ActionResult> Index(int? id)
        {
            var usuarios = await _usuarioInterface.BuscarUsuarios(id);
            return View(usuarios);
        }

        [HttpGet]
        public ActionResult Cadastrar(int? id)
        {
            ViewBag.Perfil = PerfilEnum.Administrador;

            if (id != null)
            {      
                ViewBag.Perfil = PerfilEnum.Cliente;
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Detalhes(int? id)
        {
            if(id != null)
            {
                var usuario = await _usuarioInterface.BuscarUsuarioPorId(id);
                return View(usuario);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<ActionResult> Cadastrar(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            if(ModelState.IsValid)
            {

                if (!await _usuarioInterface.VerificaSeExisteUsuarioEEmail(usuarioCriacaoDto))
                {
                    TempData["MensagemErro"] = "Já existe email/usuário cadastrado!";
                    return View(usuarioCriacaoDto);
                }

                //Cadastrar usuário
                var usuario = await _usuarioInterface.Cadastrar(usuarioCriacaoDto);

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                if (usuario.Perfil != PerfilEnum.Cliente)
                {
                    return RedirectToAction("Index", "Funcionario");
                }

                return RedirectToAction("Index", "Cliente", new { Id = "0" });


            }
            else
            {
                TempData["MensagemErro"] = "Verifique os dados informados!";
                return View(usuarioCriacaoDto);
            }
        }


        [HttpPost]
        public async Task<ActionResult> MudarSituacaoUsuario(UsuarioModel usuario)
        {
            if (usuario.Id != 0 && usuario.Id != null)
            {
                var usuarioBanco = await _usuarioInterface.MudarSituacaoUsuario(usuario.Id);

               

                    if(usuarioBanco.Situacao == true)
                    {
                        TempData["MensagemSucesso"] = "Usuário ativo com sucesso!";
                    }
                    else
                    {
                        TempData["MensagemSucesso"] = "Inativação realizada com sucesso!";
                    }

                    if(usuarioBanco.Perfil != PerfilEnum.Cliente)
                    {
                        return RedirectToAction("Index", "Funcionario");
                    }else
                    {
                        return RedirectToAction("Index", "Cliente", new {Id = "0"});
                    }
                
               
               
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}
