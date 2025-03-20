using MediatR;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.Dividend.Commands
{
    public record DeleteGenerateDividendCommand(Guid Id):IRequest;
    class DeleteGenerateDividendCommandHandler : IRequestHandler<DeleteGenerateDividendCommand>
    {
        private readonly IGenerateDividendRepository generateDividendRepository;

        public DeleteGenerateDividendCommandHandler(IGenerateDividendRepository generateDividendRepository)
        {
            this.generateDividendRepository = generateDividendRepository;
        }
        public async Task Handle(DeleteGenerateDividendCommand request, CancellationToken cancellationToken)
        {
            await generateDividendRepository.ExecutueDeleteAsync(request.Id);
        }
    }
}
