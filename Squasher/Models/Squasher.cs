using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Squasher.Models
{
    public class Squasher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Bug> Bugs { get; set; }
        public List<Project> Projects { get; set; }
    }
}