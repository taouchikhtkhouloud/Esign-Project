using System;

namespace Esign.Application.Features.DocumentTypes.Queries.GetAll
{
    public class GetAllDocumentTypesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Parent { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}