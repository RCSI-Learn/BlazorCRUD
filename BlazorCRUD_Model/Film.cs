using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCRUD_Model {
    public class Film {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
