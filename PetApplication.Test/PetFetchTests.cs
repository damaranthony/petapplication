using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PetApplication.Core.BLL;
using PetApplication.Core.Repositories;
using PetApplication.Core.Models.Entities;

namespace PetApplication.Test
{
    [TestFixture]
    public class PetFetchTests
    {
        private PetFetcher _petFetcher;
        private Mock<IDataSource> _dataSource;
        private Mock<IPersonService> _personService;
        private Mock<IPetService> _petService;

        private const string _response = "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]},{\"name\":\"Steve\",\"gender\":\"Male\",\"age\":45,\"pets\":null},{\"name\":\"Fred\",\"gender\":\"Male\",\"age\":40,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Max\",\"type\":\"Cat\"},{\"name\":\"Sam\",\"type\":\"Dog\"},{\"name\":\"Jim\",\"type\":\"Cat\"}]},{\"name\":\"Samantha\",\"gender\":\"Female\",\"age\":40,\"pets\":[{\"name\":\"Tabby\",\"type\":\"Cat\"}]},{\"name\":\"Alice\",\"gender\":\"Female\",\"age\":64,\"pets\":[{\"name\":\"Simba\",\"type\":\"Cat\"},{\"name\":\"Nemo\",\"type\":\"Fish\"}]}]";

        [SetUp]
        public void Setup()
        {

        }
    }
}
