using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.AppSettings
{
    public class AzureBlobStorageSetting
    {
        public string ContainerUrl { get; set; } = "";
        public string ConnectionString { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Key { get; set; } = "";
        public string SasToken { get; set; } = "";
    }
}
