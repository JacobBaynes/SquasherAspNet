using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Squasher.Models
{
    public class BugModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Severity { get; set; }
        public ProjectModel Project { get; set; }
        public int Squashers { get; set; }
        public string Version { get; set; }

        [DataType(DataType.Date)]
        public DateTime TrackDate { get; set; }
    }
}