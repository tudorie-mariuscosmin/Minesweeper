﻿using System;

namespace API.Models
{
    public class Winner
    {
        public long Id { get; set; }
        public string PlayerScore { get; set; }
        public string PlayerName { get; set; }
        public DateTime Date { get; set; }
    }
}