using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Squasher.Models
{
    public class BugSquasherModel
    {
        public int BugId { get; set; }
        public BugModel Bug { get; set; }

        public int SquasherId { get; set; }
        public SquasherModel Squasher { get; set; }
    }
}