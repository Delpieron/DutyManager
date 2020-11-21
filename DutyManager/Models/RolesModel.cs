using System;
using System.Collections.Generic;
using System.Text;

namespace DutyManager.Models
{
    public class RolesModel
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Role { get; set; }
    }
}
