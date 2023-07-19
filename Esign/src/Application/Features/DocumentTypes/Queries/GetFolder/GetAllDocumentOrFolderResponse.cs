using System;

namespace Esign.Application.Features.DocumentTypes.Queries.GetFolder
{
    public class GetAllDocumentOrFolderResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDocument { get; set; }

    }
}