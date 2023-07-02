using PruebaTecnica_Newshore.Data.Model;
using PruebaTecnica_Newshore.Repository.Base;
using PruebaTecnica_Newshore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace PruebaTecnica_Newshore.Repository.Implementation
{
    public class JourneyRepository : Repository<Journey>, IJourneyRepository
    {
        public JourneyRepository(string connectionString) : base(connectionString) { }
    }
}
