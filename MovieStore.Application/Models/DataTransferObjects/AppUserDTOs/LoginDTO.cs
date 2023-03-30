using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Application.Models.DataTransferObjects.AppUserDTOs
{
    internal class LoginDTO
    {
        //ToDo: Data Annotations
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
