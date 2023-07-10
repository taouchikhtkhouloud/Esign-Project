using Esign.Domain.Contracts;
using Esign.Domain.Entities.ExtendedAttributes;

namespace Esign.Domain.Entities.Misc
{
    public class Document : AuditableEntityWithExtendedAttributes<int, int, Document, DocumentExtendedAttribute>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; } = false;
        public string URL { get; set; }
        public int DocumentTypeId { get; set; }
        public string Client { get; set; }
        public string Value { get; set; }
        public string fileType { get; set; }
        public string keywords { get; set; }
        public bool status { get; set; }

        public virtual DocumentType DocumentType { get; set; }
    }
}