using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BasicAPI
{
    public class Book
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
