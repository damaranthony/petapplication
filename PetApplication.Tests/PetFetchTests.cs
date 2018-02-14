using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PetApplication.Core.BLL;
using PetApplication.Core.Repositories;
using PetApplication.Core.Models.Entities;
using AutoMoq;

namespace PetApplication.Test
{
    [TestFixture]
    public class PetFetchTests
    {
        private PetFetcher _petFetcher;
        private AutoMoqer _mocker;
        private readonly IDataSource _dataSource = new DataSource();
        private readonly IPersonService _personService = new PersonService();
        private readonly IPetService _petService = new PetService();

        private const string _response = "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]},{\"name\":\"Steve\",\"gender\":\"Male\",\"age\":45,\"pets\":null},{\"name\":\"Fred\",\"gender\":\"Male\",\"age\":40,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Max\",\"type\":\"Cat\"},{\"name\":\"Sam\",\"type\":\"Dog\"},{\"name\":\"Jim\",\"type\":\"Cat\"}]},{\"name\":\"Samantha\",\"gender\":\"Female\",\"age\":40,\"pets\":[{\"name\":\"Tabby\",\"type\":\"Cat\"}]},{\"name\":\"Alice\",\"gender\":\"Female\",\"age\":64,\"pets\":[{\"name\":\"Simba\",\"type\":\"Cat\"},{\"name\":\"Nemo\",\"type\":\"Fish\"}]}]";
        private List<Person> _malePeople = InitMaleRecords();
        private List<Person> _femalePeople = InitFemaleRecords();
        private static List<Pet> _femaleOwnedCats = InitFemaleOwnedCatsRecords();
        private static List<Pet> _maleOwnedCats = InitMaleOwnedCatsRecords();

        /// <summary>
        /// Initialize Mock setup
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _petFetcher = new PetFetcher();

            _mocker = new AutoMoqer();

            _mocker.GetMock<IDataSource>()
                .Setup(p => p.GetApiResponseString())
                .Returns(_response);

            _mocker.GetMock<IPersonService>()
                .Setup(p => p.GetFemaleOwners(_response))
                .Returns(_femalePeople);

            _mocker.GetMock<IPersonService>()
                .Setup(p => p.GetMaleOwners(_response))
                .Returns(_malePeople);

            _mocker.GetMock<IPetService>()
                .Setup(p => p.GetAllCat(_malePeople))
                .Returns(_maleOwnedCats);

            _mocker.GetMock<IPetService>()
                .Setup(p => p.GetAllCat(_femalePeople))
                .Returns(_femaleOwnedCats);

            _mocker.GetMock<IPetService>()
                .Setup(p => p.GetAllByAscendingPetName(_femaleOwnedCats))
                .Returns(_femaleOwnedCats.OrderBy(p => p.Name).ToList());

            _mocker.GetMock<IPetService>()
               .Setup(p => p.GetAllByAscendingPetName(_maleOwnedCats))
               .Returns(_maleOwnedCats.OrderBy(p => p.Name).ToList());

            _petFetcher = _mocker.Create<PetFetcher>();
        }
        
        /// <summary>
        /// #1 Verify if DataSource.GetApiResponseString() has been executed once
        /// </summary>
        [Test]
        public void TestExecuteDataSource()
        {
            _petFetcher.GetAllPetsByOwnerGender();

            _mocker.GetMock<IDataSource>()  
                .Verify(p => p.GetApiResponseString(), Times.Once);
        }

        /// <summary>
        /// #2 Check if API response is correct
        /// </summary>
        [Test]
        public void TestDataSourceResponse()
        {
            var result = _dataSource.GetApiResponseString();

            Assert.AreEqual(result, _mocker.GetMock<IDataSource>().Object.GetApiResponseString());
        }

        /// <summary>
        /// #3 Verify if PersonService.GetMaleOwners(responseString) has been executed once
        /// </summary>
        [Test]
        public void TestExecutePersonServiceGetMaleOwners()
        {
            _petFetcher.GetAllPetsByOwnerGender();

            _mocker.GetMock<IPersonService>()
                .Verify(p => p.GetMaleOwners(_response), Times.Once);
        }

        /// <summary>
        /// #4 Verify if PersonService.GetFemaleOwners(responseString) has been executed once
        /// </summary>
        [Test]
        public void TestExecutePersonServiceGetFemaleOwners()
        {
            _petFetcher.GetAllPetsByOwnerGender();

            _mocker.GetMock<IPersonService>()
                .Verify(p => p.GetFemaleOwners(_response), Times.Once);
        }

        /// <summary>
        /// #5 Verify if PetService.GetAllCat(List<person> people) has been executed once
        /// </summary>
        [Test]
        public void TestExecutePetServiceGetAllCat()
        {
            _petFetcher.GetAllPetsByOwnerGender();

            _mocker.GetMock<IPetService>()
                .Verify(p => p.GetAllCat(_malePeople), Times.Once);
        }

        /// <summary>
        /// #6 Verify results of GetFemaleOwners() method
        /// </summary>
        [Test]
        public void TestPersonalServiceGetFemaleOwnersResult()
        {
            var result = _personService.GetFemaleOwners(_response).ToList();

            CollectionAssert.AreEqual(result, _mocker.GetMock<IPersonService>().Object.GetFemaleOwners(_response));
        }

        /// <summary>
        /// #7 Verify results of GetMaleOwners() method
        /// </summary>
        [Test]
        public void TestPersonalServiceGetMaleOwnersResult()
        {
            var result = _personService.GetMaleOwners(_response).ToList();

            CollectionAssert.AreEqual(result, _mocker.GetMock<IPersonService>().Object.GetMaleOwners(_response));
        }

        /// <summary>
        /// #8 Verify results for GetAllCat() from female owners
        /// </summary>
        [Test]
        public void TestPetServiceGetAllCatFromFemaleOwnersResult()
        {
            var result = _petService.GetAllCat(_femalePeople).ToList();

            CollectionAssert.AreEqual(result, _mocker.GetMock<IPetService>().Object.GetAllCat(_femalePeople));
        }

        /// <summary>
        /// #9  Verify results for GetAllCat() from male owners
        /// </summary>
        [Test]
        public void TestPetServiceGetAllCatFromMaleOwnersResult()
        {
            var result = _petService.GetAllCat(_malePeople).ToList();

            CollectionAssert.AreEqual(result, _mocker.GetMock<IPetService>().Object.GetAllCat(_malePeople));
        }

        /// <summary>
        /// #10 Verify results of male owned cats if ordered by ascending 
        /// </summary>
        [Test]
        public void TestPetServiceCheckMaleOwnedCatsIfOrderAscending()
        {
            var expected = _petService.GetAllByAscendingPetName(_maleOwnedCats);
            var result = _mocker.GetMock<IPetService>().Object.GetAllByAscendingPetName(_maleOwnedCats);

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        /// <summary>
        /// #11 Verify results of female owned cats if ordered by ascending 
        /// </summary>
        [Test]
        public void TestPetServiceCheckFemaleOwnedCatsIfOrderAscending()
        {
            var expected = _petService.GetAllByAscendingPetName(_femaleOwnedCats);
            var result = _mocker.GetMock<IPetService>().Object.GetAllByAscendingPetName(_femaleOwnedCats);

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        /// <summary>
        /// Initialize list of Pet objects for female owned cats
        /// </summary>
        /// <returns>Returns a list of Pet object</returns>
        private static List<Pet> InitFemaleOwnedCatsRecords()
        {
            return new List<Pet>
            {
                new Pet{ Name = "Garfield", Type = "Cat"},
                new Pet{ Name = "Tabby", Type = "Cat"},
                new Pet{ Name = "Simba", Type = "Cat"}
            };
        }
        
        /// <summary>
        /// Initialize list of Pet objects for male owned cats
        /// </summary>
        /// <returns>Returns a list of Pet object</returns>
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

        /// <summary>
        /// Initialize list of Person object for female records
        /// </summary>
        /// <returns>Returns list of Person object</returns>
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

        /// <summary>
        /// Initialize list of Person object for male records
        /// </summary>
        /// <returns>Returns list of Person object</returns>
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
