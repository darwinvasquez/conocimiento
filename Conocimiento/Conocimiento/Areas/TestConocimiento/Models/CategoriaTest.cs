using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Conocimiento.Areas.TestConocimiento.Models
{
    /// <summary>
    /// Tabla que permite almacenar las categorias
    /// </summary>
    [Table("CategoriaTest")]

    public class CategoriaTest
    {
        /// <summary>
        /// Autoincromento Categoria test
        /// </summary>
        [Column("CategoriaTestId"), Key]
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaTestId { get; set; }

        ///// <summary>
        ///// Nombre categoria
        ///// </summary>
        [Column("Nombre")]
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 100")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        ///// <summary>
        ///// Estado Categoria
        ///// </summary>
        [Required]
        [Column("Estado")]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        #region propiedades de navegacion

        ///// <summary>
        ///// propiedad de navegacion hacia las preguntas
        ///// </summary>
        public virtual ICollection<PreguntaTest> PreguntaTest { get; set; }

        #endregion

    }
}