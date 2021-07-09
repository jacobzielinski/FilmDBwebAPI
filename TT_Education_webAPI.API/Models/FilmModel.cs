using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TT_Education_webAPI.API.Models
{
    public class FilmModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string YearOfProduction { get; set; }
        public List<GenreModel> Genres { get ; set; }
        public string UserNotes { get; set; }
        public bool IsDeleted { get; set; }
    }
}
