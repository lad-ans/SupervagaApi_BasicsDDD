using Supervaga.Domain.Shared.Contracts.Entities;

namespace Supervaga.Domain.Documents
{
    public class Document : Entity
    {
        public Document()
        {
        }

        public string? FileName { get; set; }
        public string? FileUrl { get; set; }
        public string? ContentType { get; set; }
        public long? FileSize { get; set; }
    }
}