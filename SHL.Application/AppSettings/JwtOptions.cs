using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.AppSettings
{
    public class JwtOptions
    {
        public string? IssuerName { get; init; }
        public string? Audience { get; init; }
        public string? SecretKey { get; init; }
    }
}
