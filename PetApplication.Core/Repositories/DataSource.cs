using System;
using System.Collections.Generic;
using PetApplication.Core.Models.Entities;

namespace PetApplication.Core.Repositories
{
    public class DataSource : IDataSource
    {
        public IEnumerable<Person> GetData()
        {
            throw new NotImplementedException();
        }
    }
}
