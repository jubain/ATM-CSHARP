﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.ConceptArt.Models
{
    public class ImportanceDetails
    {
        public int ImportanceId { get; set; }
        public string Name { get; set; }
        public int Hierarchy { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }


    }
}
