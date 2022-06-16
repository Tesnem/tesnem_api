using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.DTO.RequestDTO
{
    public class CourseRequest
    {
       public string Name { get; set; }
       public List<CourseRequirementsRequest> Requirement { get; set; } = new List<CourseRequirementsRequest>();
       public Guid ProgramId { get; set; }
    }
}
