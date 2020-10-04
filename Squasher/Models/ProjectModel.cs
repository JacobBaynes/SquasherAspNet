using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Squasher.Models;
using System.Collections.Generic;

namespace Squasher.Models
{
    public class ProjectModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public ICollection<BugModel> Bugs { get; set; }
        public ICollection<ProjectSquasherModel> ProjectSquashers { get; set; }
    }
}