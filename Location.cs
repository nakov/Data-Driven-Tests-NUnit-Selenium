﻿using System.Collections.Generic;

namespace Tests_Data_Driven
{
    public class Location
    {
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string CountryAbbreviation { get; set; }
        public List<Place> Places { get; set; }
    }
}