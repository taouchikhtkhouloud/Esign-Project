using System;

namespace Esign.Application.Features.Documents.Queries.GetAll
{
    public class GetAllDocumentsResponse
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
        public string NomSignateur { get; set; }
        public string PrenomSignateur { get; set; }
        public string FileUrlsSigne { get; set; }
        public DateTime DateSignature { get; set; }
    }
}