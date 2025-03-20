using SHL.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.ContractDocument
{
    public class CreateContractDocumentDto
    {
        public string DocumentName { get; set; } = default!;
        public ContractDocumentType ContractDocumentType { get; set; }
        public string? DocumentContentUrl { get; set; }
        public string? DocumentContent { get; set; }
    }
}
