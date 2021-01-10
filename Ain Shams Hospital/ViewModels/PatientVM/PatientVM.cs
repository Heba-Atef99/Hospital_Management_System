using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_University.ViewModels
{
    public class PatientVM
    {
        public int Id { set; get; }
        public IFormFile Image { get; set; }
    }
}
