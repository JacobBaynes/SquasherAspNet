using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Squasher.Models;
using System.Collections.Generic;

namespace Squasher.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<BugModel> Bugs { get; set; }
        public List<SquasherModel> Squashers { get; set; }
    }
}