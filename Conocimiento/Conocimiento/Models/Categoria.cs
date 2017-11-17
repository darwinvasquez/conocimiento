using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Conocimiento.Models
{   

    /// <summary>
    /// Tabla que almacena las categorias
    /// </summary>
    [Table("Categoria")]
    public class Categoria
    {
        /// <summary>
        /// Incrementi 
        /// </summary>
        [Column("CategoriaId"), Key]
        public int CategoriaId { get; set; }

        /// <summary>
        /// Nombre del departamento
        /// </summary>
        [Column("Descripcion")]
        [StringLength(200, ErrorMessage = "Lo maximo es de 200 caracteres", MinimumLength  =1)]
        public string Descripcion { get; set; }

        /// <summary>
        /// Nombre del departamento
        /// </summary>
        [Column("Icons")]      
        public string Icons { get; set; }      

        /// <summary>
        /// Indica si el departamento esta activo o no
        /// </summary>
        [Column("EstaActivo")]
        public bool EstaActivo { get; set; }

        #region Propiedades de navegación
        

        #endregion
    }


}