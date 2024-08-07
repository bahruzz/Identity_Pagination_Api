﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }
        public int SeatCount { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
