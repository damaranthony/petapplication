using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetApplication.Core.Models.Entities;
using Newtonsoft.Json;

namespace PetApplication.Core.Common.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Converts a response string into a list of person object
        /// </summary>
        /// <param name="responseString">Indicates the current string</param>
        /// <returns>A list of Person object</returns>
        public static IEnumerable<Person> ToPersonEntities(this string responseString)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Person>>(responseString);
        }
    }
}
