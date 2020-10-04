using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Squasher.Models
{
    public class ProjectSquasherModel
    {
        public int ProjectId { get; set; }
        public ProjectModel Project { get; set; }

        public int SquasherId { get; set; }
        public SquasherModel Squasher { get; set; }
    }
}