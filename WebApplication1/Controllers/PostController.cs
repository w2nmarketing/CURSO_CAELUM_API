using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class PostController : ControllerBase
    {

        private readonly PostDao _dao;

        public PostController(PostDao dao)
        {
            this._dao = dao;
        }

        [Route("v1/posts")]
        [HttpGet]
        public IActionResult Posts()
        {

            try
            {

                List<Post> lista = _dao.ListarPost();

                return Ok(lista);

            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }

        }

        [Route("v1/posts")]
        [HttpPost]
        public IActionResult Salvar_Post([FromBody] Post novaPost)
        {

            try
            {

                int id = _dao.Adicionar(novaPost);

                return Ok(id);

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        [Route("v1/posts/{id}")]
        [HttpDelete]
        public IActionResult Deletar_Post(int id)
        {

            _dao.Excluir(id);

            return Ok();

        }

        [Route("v1/post/publicar/{id}")]
        [HttpPut]
        public IActionResult Publicar_Post(int id)
        {

            _dao.Publicar(id);

            return Ok();

        }

        [Route("v1/posts/{id}")]
        [HttpPut]
        public IActionResult Atualizar_Post([FromBody] Post alteradoPost, int id)
        {

            alteradoPost.Id = id;

            _dao.Alterar(alteradoPost);

            return Ok();

        }

    }
}