using System.Collections.Generic;
using System.Linq;
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
        private Mock<IDataSource> _mockDataSource;
        private Mock<IPersonService> _mockPersonService;
        private Mock<IPetService> _mockPetService;

        private const string _response = "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]},{\"name\":\"Steve\",\"gender\":\"Male\",\"age\":45,\"pets\":null},{\"name\":\"Fred\",\"gender\":\"Male\",\"age\":40,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Max\",\"type\":\"Cat\"},{\"name\":\"Sam\",\"type\":\"Dog\"},{\"name\":\"Jim\",\"type\":\"Cat\"}]},{\"name\":\"Samantha\",\"gender\":\"Female\",\"age\":40,\"pets\":[{\"name\":\"Tabby\",\"type\":\"Cat\"}]},{\"name\":\"Alice\",\"gender\":\"Female\",\"age\":64,\"pets\":[{\"name\":\"Simba\",\"type\":\"Cat\"},{\"name\":\"Nemo\",\"type\":\"Fish\"}]}]";

        private List<Person> _malePeople = InitMaleRecords();
        private List<Person> _femalePeople = InitFemaleRecords();
        private List<Pet> _femaleOwnedCats = InitFemaleOwnedCatsRecords();
        private List<Pet> _maleOwnedCats = InitMaleOwnedCatsRecords();
        private List<Pet> _femaleOwnedCatsAsc = InitFemaleOwnedCatsRecordsAsc();
        private List<Pet> _maleOwnedCatsAsc = InitMaleOwnedCatsRecordsAsc();

        [SetUp]
        public void Setup()
        {
            _petFetcher = new PetFetcher();
            _mockDataSource = new Mock<IDataSource>();
            _mockPersonService = new Mock<IPersonService>();
            _mockPetService = new Mock<IPetService>();

            _mockDataSource
                .Setup(p => p.GetDataAsync().ToString())
                .Returns(_response);

            _mockPersonService
                .Setup(p => p.GetFemaleOwners(_response).ToList())
                .Returns(_femalePeople);

            _mockPersonService
                .Setup(p => p.GetFemaleOwners(_response).ToList())
                .Returns(_malePeople);

            _mockPetService
                .Setup(p => p.GetAllCat(_malePeople).ToList())
                .Returns(_maleOwnedCats);

            _mockPetService
                .Setup(p => p.GetAllCat(_femalePeople).ToList())
                .Returns(_femaleOwnedCats);


            _mockPetService
                .Setup(p => p.GetAllByAscendingPetName(_femaleOwnedCats))
                .Returns(_femaleOwnedCatsAsc);

            _mockPetService
               .Setup(p => p.GetAllByAscendingPetName(_maleOwnedCats))
               .Returns(_maleOwnedCatsAsc);

            _petFetcher = new PetFetcher(
                _mockDataSource.Object,
                _mockPersonService.Object,
                _mockPetService.Object);
        }

        [Test]
        public void TestExecuteDatasource()
        {
            _petFetcher.GetAllPetsByOwnerGender();

            _mockDataSource.Verify(p => p.GetDataAsync().ToString(), Times.Once);
        }

        private static List<Pet> InitFemaleOwnedCatsRecords()
        {
            return new List<Pet>
            {
                new Pet{ Name = "Garfield", Type = "Cat"},
                new Pet{ Name = "Tabby", Type = "Cat"},
                new Pet{ Name = "Simba", Type = "Cat"}
            };
        }

        private static List<Pet> InitFemaleOwnedCatsRecordsAsc()
        {
            return new List<Pet>
            {
                new Pet{ Name = "Garfield", Type = "Cat"},
                 new Pet{ Name = "Simba", Type = "Cat"},
                new Pet{ Name = "Tabby", Type = "Cat"}
            };
        }

        private static List<Pet> InitMaleOwnedCatsRecords()
        {
            return new List<Pet>
            {
                new Pet{ Name = "Garfield", Type = "Cat"},
                new Pet{ Name = "Tom", Type = "Cat"},
                new Pet{ Name = "Max", Type = "Cat"},
                new Pet{ Name = "Jim", Type = "Cat"}
            };
        }

        private static List<Pet> InitMaleOwnedCatsRecordsAsc()
        {
            return new List<Pet>
            {
                new Pet{ Name = "Garfield", Type = "Cat"},
                new Pet{ Name = "Jim", Type = "Cat"},
                new Pet{ Name = "Max", Type = "Cat"},
                new Pet{ Name = "Tom", Type = "Cat"}
            };
        }
        private static List<Person> InitFemaleRecords()
        {
            return new List<Person>
            {
                new Person{
                    Name = "Jennifer",
                    Gender = "Female",
                    Age = 18,
                    Pets = new List<Pet>
                    {
                        new Pet{ Name = "Garfield", Type = "Cat"}
                    }
                },
                new Person{
                    Name = "Samantha",
                    Gender = "Female",
                    Age = 40,
                    Pets = new List<Pet>
                    {
                        new Pet{ Name = "Tabby", Type = "Cat"}
                    }
                },
                 new Person{
                    Name = "Alice",
                    Gender = "Female",
                    Age = 64,
                    Pets = new List<Pet>
                    {
                        new Pet{ Name = "Simba", Type = "Cat"},
                        new Pet{ Name = "Nemo", Type = "Fish"},
                    }
                }
            };
        }

        private static List<Person> InitMaleRecords()
        {
            return new List<Person>
            {
                new Person{
                    Name = "Bob",
                    Gender = "Male",
                    Age = 23,
                    Pets = new List<Pet>
                    {
                        new Pet{ Name = "Garfield", Type = "Cat"},
                        new Pet{ Name = "Fido", Type = "Dog"}
                    }
                },
                new Person{
                    Name = "Fred",
                    Gender = "Male",
                    Age = 40,
                    Pets = new List<Pet>
                    {
                        new Pet{ Name = "Tom", Type = "Cat"},
                        new Pet{ Name = "Max", Type = "Cat"},
                        new Pet{ Name = "Sam", Type = "Dog"},
                        new Pet{ Name = "Jim", Type = "Cat"},
                    }
                }
            };
        }
    }
}
