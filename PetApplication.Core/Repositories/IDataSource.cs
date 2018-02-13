using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetApplication.Core.Models.Entities;

namespace PetApplication.Core.Repositories
{
    public interface IDataSource
    {
        IEnumerable<Person> GetData();
    }
}
