using Esign.Domain.Entities.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esign.Application.Requests.Documents
{
    public class SignDocumentRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Code { get; set; }
       
    }
}
