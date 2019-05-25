using System;
using System.Collections.Generic;
using System.Text;
using Mayparcabrera2.Models;


namespace Mayparcabrera2.Models
{
    using System.ComponentModel.DataAnnotations;


    class Note
    {
        [Key]
        public int NotesId { get; set; }
        public string Contents { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Note()
        {
            this.CreatedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
        }
    }
}
