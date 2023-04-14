using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PatrnersTestContext.Models
{
    internal class Streetcode
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Title { get; set; }

        public List<Partner> Partners { get; set; }
    }
}
