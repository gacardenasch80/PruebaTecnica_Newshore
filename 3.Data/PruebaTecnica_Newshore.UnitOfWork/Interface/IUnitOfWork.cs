using PruebaTecnica_Newshore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica_Newshore.UnitOfWork.Interface
{
    /// <summary>
    /// interface IUnitOfWork
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Interface Journey
        /// </summary>
        IJourneyRepository Journey { get; }
    }
}
