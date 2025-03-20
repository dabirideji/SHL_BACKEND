using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.VestedShareTransfer
{
    public class UploadProcessedSharesDto
    {
        public IFormFile File { get; set; } = default!;
    }
}
