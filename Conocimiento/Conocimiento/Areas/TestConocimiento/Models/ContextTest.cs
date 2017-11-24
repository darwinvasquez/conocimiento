using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Conocimiento.Areas.TestConocimiento.Models
{
    public class ContextTest : DbContext
    {
        public ContextTest()
            :base("DefaultConnection")
        {
        }

        public virtual DbSet<CategoriaTest> CategoriaTest { get; set; }
        public virtual DbSet<PreguntaTest> PreguntaTest { get; set; }
        public virtual DbSet<RespuestaTest> RespuestaTest { get; set; }

        public System.Data.Entity.DbSet<Conocimiento.Models.Categoria> Categorias { get; set; }
    }
}