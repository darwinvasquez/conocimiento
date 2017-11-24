using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Conocimiento.Areas.TestConocimiento.Models
{
    /// <summary>
    /// Tabla que permite almacenar las preguntas
    /// </summary>
    [Table("PreguntaTest")]
    public class PreguntaTest
    {
        /// <summary>
        /// Autoincromento Categoria test
        /// </summary>
        [Column("PreguntaTestId"), Key]
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PreguntaTestId { get; set; }

        /// <summary>
        /// Categoria de la preguntsa
        /// </summary>        
        [Column("CategoriaTestId")]
        [Display(Name = "Categoría")]
        public int CategoriaTestId { get; set; }
        
        ///// <summary>
        ///// Nombre de la pregunta
        ///// </summary>
        [Column("Pregunta")]
        [Required]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "La cantidad máxima de caracteres son 500")]
        [Display(Name = "Pregunta")]
        public string Pregunta { get; set; }

        ///// <summary>
        ///// Estado Categoria
        ///// </summary>
        [Required]
        [Column("Estado")]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        #region propiedades de navegacion

        ///// <summary>
        ///// Propiedad de navegacion hacia Categoria test
        ///// </summary>
        [ForeignKey("CategoriaTestId")]
        public virtual CategoriaTest CategoriaTest { get; set; }

        ///// <summary>
        ///// Propiedad de navegacion hacia respuesta test
        ///// </summary>        
        public virtual ICollection<RespuestaTest> RespuestaTest { get; set; }

        #endregion
    }
}