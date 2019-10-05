using Blog.Infra;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.DAO
{
    public class PostDao
    {

        private readonly BlogContext _contexto; // SO PODE SER INSTANCIADO NO CONTRUTOR

        public PostDao(BlogContext contexto)
        {
            _contexto = contexto;
        }

        #region ENTITY

        public List<Post> ListarPost()
        {
            return _contexto.Post.ToList();
        }



        public List<Post> ListarPostPublicado()
        {

            return _contexto.Post.Where(p => p.Publicado == true).ToList();

        }



        public List<Post> ListarPostCategoria(string categoria)
        {


            return _contexto.Post.Where(c => c.Categoria == categoria).ToList();


        }

        public int Adicionar(Post novoPost)
        {

            _contexto.Post.Add(novoPost);
            _contexto.SaveChanges();

            return novoPost.Id;



        }

        public void Excluir(int id)
        {

            Post postSelecionado = _contexto.Post.Where(c => c.Id == id).FirstOrDefault();

            //Post postSelecionado = contexto.Post.Find(id);

            _contexto.Post.Remove(postSelecionado);

            _contexto.SaveChanges();


        }

        public Post BuscarId(int id)
        {


            Post postSelecionado = _contexto.Post.Where(c => c.Id == id).FirstOrDefault();

            //Post postSelecionado = contexto.Post.Find(id);

            return postSelecionado;


        }

        public void Alterar(Post novoPost)
        {

            _contexto.Post.Update(novoPost);
            _contexto.SaveChanges();

            //contexto.Entry(novoPost).State = EntityState.Modified;
            //contexto.SaveChanges();

        }

        public void Publicar(int id)
        {

            Post postSelecionado = _contexto.Post.Find(id);

            postSelecionado.Publicado = true;
            postSelecionado.DataPublicacao = DateTime.Now;

            _contexto.Post.Update(postSelecionado);

            _contexto.SaveChanges();

        }

        #endregion

        #region ADO_NET

        //    public List<Post> ListarPost()
        //    {

        //        List<Post> lista_Posts = new List<Post>();

        //        using (SqlConnection conexao = ConnectionFactory.CriaConexao())
        //        {

        //            SqlCommand cmd = conexao.CreateCommand();
        //            cmd.CommandText = "SELECT * FROM Post;";
        //            SqlDataReader leitor = cmd.ExecuteReader();

        //            while (leitor.Read())
        //            {

        //                lista_Posts.Add(new Post(leitor["Categoria"].ToString(), leitor["Titulo"].ToString()) { Resumo = leitor["Resumo"].ToString() });

        //            }

        //        }

        //        return lista_Posts;

        //    }

        //    public void Adicionar(Post novoPost)
        //{

        //    using (SqlConnection conexao = ConnectionFactory.CriaConexao())
        //    {

        //        SqlCommand cmd = conexao.CreateCommand();
        //        cmd.CommandText = $"INSERT INTO Post (Titulo, Resumo, Categoria) " +
        //            $"VALUES (@titulo, @resumo, @categoria);";

        //        cmd.Parameters.Add(new SqlParameter("titulo", novoPost.Titulo));
        //        cmd.Parameters.Add(new SqlParameter("resumo", novoPost.Resumo));
        //        cmd.Parameters.Add(new SqlParameter("categoria", novoPost.Categoria));

        //        cmd.ExecuteNonQuery();

        //    }

        //}

        #endregion

    }
}
