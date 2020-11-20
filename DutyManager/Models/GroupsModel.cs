using System;
using System.Collections.Generic;
using System.Text;

namespace DutyManager.Models
{
    public class GroupsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<UsersModel> Members { get; set; }
    }
}
