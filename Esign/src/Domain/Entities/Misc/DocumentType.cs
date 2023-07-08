using Esign.Domain.Contracts;

namespace Esign.Domain.Entities.Misc
{
    public class DocumentType : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int Parent { get; set; }

    }
}