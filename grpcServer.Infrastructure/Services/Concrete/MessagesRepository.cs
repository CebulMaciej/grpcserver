using System.Collections.Generic;
using System.Threading.Tasks;
using grpcServer.Infrastructure.Services.Abstract;

namespace grpcServer.Infrastructure.Services.Concrete
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly ICollection<string> _collection;

        public MessagesRepository()
        {
            _collection = new List<string>();
        }

        public Task<IEnumerable<string>> GetMessages()
            => Task.FromResult((IEnumerable<string>)_collection);

        public Task AddMessage(string message)
        {
            _collection.Add(message);
            return Task.CompletedTask;
        }
    }
}