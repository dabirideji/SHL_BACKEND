using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.File
{
    public class UploadDto
    {
        public IFormFile File { get; set; } = default!;
        public string FolderName { get; set; } = default!;
    }
}
