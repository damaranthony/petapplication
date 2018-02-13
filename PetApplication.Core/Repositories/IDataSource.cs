using System.Threading.Tasks;

namespace PetApplication.Core.Repositories
{
    public interface IDataSource
    {
        Task<string> GetDataAsync();
    }
}
