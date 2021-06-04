using System.Collections.Generic;
using System.Threading.Tasks;

namespace grpcServer.Infrastructure.Services.Abstract
{
    public interface IMessagesRepository
    {
        Task<IEnumerable<string>> GetMessages();
        Task AddMessage(string message);
    }
}