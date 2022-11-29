using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Dtos.User
{
    public class LoginDto
    {
        public string Name { get; set; }=string.Empty;
        public string password { get; set; }=string.Empty;
    }
}