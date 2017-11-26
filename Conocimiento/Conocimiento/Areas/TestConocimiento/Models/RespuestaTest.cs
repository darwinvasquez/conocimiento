using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Conocimiento.Areas.TestConocimiento.Models
{
    /// <summary>
    /// Tabla que permite almacenar las respuestas de las preguntas
    /// </summary>
    [Table("RespuestaTest")]
    public class RespuestaTest
    {
        /// <summary>
        /// Autoincromento Categoria test
        /// </summary>
        [Column("RespuestaTestId"), Key]
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RespuestaTestId { get; set; }

        /// <summary>
        /// Llave foranea de la preguntsa
        /// </summary>        
        [Column("PreguntaTestId")]
        [Display(Name = "Pregunta")]
        public int PreguntaTestId { get; set; }

        ///// <summary>
        ///// Rspuesta de la pregunta
        ///// </summary>
        [Column("Respuesta")]
        [Required]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "La cantidad máxima de caracteres son 500")]
        [Display(Name = "Respuesta")]
        public string Respuesta { get; set; }

        ///// <summary>
        ///// Respuesta correcta
        ///// </summary>
        [Required]
        [Column("Correcta")]
        [Display(Name = "Correcta")]
        public bool Correcta { get; set; }

        ///// <summary>
        ///// Estado respuesta
        ///// </summary>
        [Required]
        [Column("Estado")]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        #region propiedades de navegacion

        ///// <summary>
        ///// Propiedad de navegacion hacia pregunta test
        ///// </summary>
        [ForeignKey("PreguntaTestId")]
        public virtual PreguntaTest PreguntaTest { get; set; }

        #endregion
    }
}