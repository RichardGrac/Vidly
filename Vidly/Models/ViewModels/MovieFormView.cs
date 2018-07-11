using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models.ViewModels
{
    public class MovieFormView
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}