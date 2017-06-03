using System.Threading.Tasks;

namespace Domain
{
    public interface IDbRepository
    {
        Task CreateDatabase();

        Task ResetData();
    }
}