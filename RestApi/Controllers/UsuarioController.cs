using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestApi.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private static List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();

        [AcceptVerbs("POST")]
        [Route("CadastrarUsuario")]
        public string CadastrarUsuario(UsuarioModel usuario)
        {
            listaUsuarios.Add(usuario);
            return "Usuario cadastrado com sucesso!";
        }
        [AcceptVerbs("PUT")]
        [Route("AlterarUsuarui")]
        public string AlterarUsuario(UsuarioModel usuario)
        {
            listaUsuarios.Where(n => n.Codigo == usuario.Codigo)
                         .Select(s =>
                         {
                             s.Codigo = usuario.Codigo;
                             s.Login = usuario.Login;
                             s.Nome = usuario.Nome;

                             return s;
                             
                         }).ToList();
            return "Usuario Cadastrado com sucesso!";
        }

        [AcceptVerbs("DELETE")]
        [Route("ExcluirUsuario/{codigo}")]
        public string DeletarUsuario(int codigo)
        {
            UsuarioModel usuario = listaUsuarios.Where(n => n.Codigo == codigo).Select(n => n).FirstOrDefault();
            listaUsuarios.Remove(usuario);
            return "Registro escluido com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarioPorCodigo/{codigo}")]
        public UsuarioModel ConsultarUsuarioPorCodigo(int codigo)
        {
            UsuarioModel usuario = listaUsuarios.Where(n => n.Codigo == codigo).Select(n => n).FirstOrDefault();
            return usuario;
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarios")]
        public List<UsuarioModel> ConsultarUsuarios()
        {
            return listaUsuarios;
        }

    }
}
