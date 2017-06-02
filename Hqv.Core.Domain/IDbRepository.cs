using System.Threading.Tasks;

namespace Hqv.Core.Domain
{
    public interface IDbRepository
    {
        Task CreateDatabase();

        Task ResetData();
    }
}