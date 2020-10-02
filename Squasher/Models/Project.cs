using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Squasher.Models;
using System.Collections.Generic;

namespace Squasher.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Bug> Bugs { get; set; }
        public List<Squasher> Squashers { get; set; }
    }
}