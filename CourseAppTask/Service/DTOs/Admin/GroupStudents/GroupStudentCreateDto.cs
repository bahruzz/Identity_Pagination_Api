using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Admin.GroupStudents
{
    public class GroupStudentCreateDto
    {
        public int StudentId { get; set; }
        public int GroupId { get; set; }
    }
}
