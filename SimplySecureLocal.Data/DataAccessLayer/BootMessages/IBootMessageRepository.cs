using SimplySecureLocal.Data.Models;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.BootMessages
{
    public interface IBootMessageRepository
    {
        Task CreateBootMessage(BootMessage bootMessage);
    }
}