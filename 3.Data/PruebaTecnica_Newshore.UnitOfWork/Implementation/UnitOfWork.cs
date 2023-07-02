using PruebaTecnica_Newshore.Repository.Implementation;
using PruebaTecnica_Newshore.Repository.Interfaces;
using PruebaTecnica_Newshore.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica_Newshore.UnitOfWork.Implementation
{
    /// <summary>
    /// class UnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Constructor de la UnitOfWork
        /// </summary>
        /// <param name="connectionString"></param>
        public UnitOfWork(string connectionString)
        {
            Journey = new JourneyRepository(connectionString);
        }
        /// <summary>
        /// Interface Journey
        /// </summary>
        public IJourneyRepository Journey { get; private set; }
    }
}
