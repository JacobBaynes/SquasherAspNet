using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Squasher.Models
{
    public class SquasherModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<BugSquasherModel> BugSquashers { get; set; }
        public ICollection<ProjectSquasherModel> ProjectSquashers { get; set; }
    }
}