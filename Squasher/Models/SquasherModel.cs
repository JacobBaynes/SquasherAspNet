using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Squasher.Models
{
    public class SquasherModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BugModel> Bugs { get; set; }
        public List<ProjectModel> Projects { get; set; }
    }
}