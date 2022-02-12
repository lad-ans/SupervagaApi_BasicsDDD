using Microsoft.AspNetCore.Http;
using Supervaga.Domain.Documents;
using Supervaga.Domain.Shared.Contracts.Commands;

namespace Supervaga.Domain.DocumentCommands
{
    public class DocumentCommand : Command
    {
        public DocumentCommand()
        {
        }

        public DocumentCommand(List<IFormFile>? docs)
        {
            this.docs = docs;
        }

        public List<IFormFile>? docs { get; set; }

        public void Validate() => Validate<DocumentCommand>(this, new DocumentValidator());
    }
}