using System.Threading.Tasks;

namespace $safeprojectname$
{
    public interface IDbRepository
    {
        Task CreateDatabase();

        Task ResetData();
    }
}