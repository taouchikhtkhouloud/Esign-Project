using System;

namespace Esign.Application.Features.Documents.Queries.GetByFolderId
{
    public class GetDocumentByFolderIdResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string URL { get; set; }
        public string Client { get; set; }
        public string Value { get; set; }
        public string fileType { get; set; }
        public string keywords { get; set; }
        public bool status { get; set; }
        public string DocumentType { get; set; }
        public int DocumentTypeId { get; set; }

    }
}