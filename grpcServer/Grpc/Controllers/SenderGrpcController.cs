using System;
using System.Threading.Tasks;
using Grpc.Core;
using grpcServer.Infrastructure.Services.Abstract;

namespace grpcServer.Grpc.Controllers
{
    public class SenderGrpcController : Sender.SenderBase
    {
        private readonly IMessagesRepository _messagesRepository;

        public SenderGrpcController(IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }

        public override async Task<SendReply> Send(SendRequest request, ServerCallContext context)
        {
            await _messagesRepository.AddMessage(request.Data);
            return new SendReply(new SendReply
            {
                Data = request.Data + DateTime.Now
            });
        }
    }
}