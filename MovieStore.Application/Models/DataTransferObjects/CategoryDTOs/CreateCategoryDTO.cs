using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Application.Models.DataTransferObjects.CategoryDTOs
{
    public class CreateCategoryDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
