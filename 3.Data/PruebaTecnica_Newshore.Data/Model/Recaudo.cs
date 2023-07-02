using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica_Newshore.Data.Model
{
    /// <summary>
    /// class User
    /// </summary>
    public class Recaudo
    {
        /// <summary>
        /// Id de la tabla Recaudo
        /// </summary>
        [ExplicitKey]
        public int Id { get; set; }
        /// <summary>
        /// Estacion de la tabla Recaudo
        /// </summary>
        public string Estacion { get; set; }
        /// <summary>
        /// Sentido de la tabla Recaudo
        /// </summary>
        public string Sentido { get; set; }
        /// <summary>
        /// Hora de la tabla Recaudo
        /// </summary>
        public string Hora { get; set; }
        /// <summary>
        /// Categoria de la tabla Recaudo
        /// </summary>
        public string Categoria { get; set; }
        /// <summary>
        /// Cantidad de la tabla Recaudo
        /// </summary>
        public int Cantidad { get; set; }
        /// <summary>
        /// ValorTabulado de la tabla Recaudo
        /// </summary>
        public int ValorTabulado { get; set; }
        /// <summary>
        /// Fecha de la tabla Recaudo
        /// </summary>
        public DateTime Fecha { get; set; }
    }
}
