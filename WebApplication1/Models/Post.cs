using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{

    //[Table("tbl_post")]
    public class Post
    {

        //[Column("id")]
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Campo com no máximo 100 caracteres")]
        [Required(ErrorMessage = "Título é Obrigatorio")]
        public string Titulo { get; set; }

        [StringLength(200, ErrorMessage = "Campo com no máximo 200 caracteres")]
        [Required(ErrorMessage = "Resumo é Obrigatorio")]
        public string Resumo { get; set; }

        [StringLength(50, ErrorMessage = "Campo com no máximo 50 caracteres")]
        [Required(ErrorMessage = "Categoria é Obrigatorio")]
        public string Categoria { get; set; }

        public bool Publicado { get; set; }
        public DateTime? DataPublicacao { get; set; }

        public Post() { }

        public Post(string categoria, string titulo)
        {
            this.Categoria = categoria;
            this.Titulo = titulo;
        }

        public Post(string categoria, string titulo, string resumo)
        {
            this.Categoria = categoria;
            this.Titulo = titulo;
            this.Resumo = resumo;
        }

    }
}
