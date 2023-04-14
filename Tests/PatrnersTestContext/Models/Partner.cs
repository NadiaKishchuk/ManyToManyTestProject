using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PatrnersTestContext.Models
{
    internal class Partner
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Title { get; set; }

        public List<Streetcode> Streetcodes { get; set; }
    }

    internal class StreetcodePartner {

        public int StreetcodeId { get; set; }
        public int PartnerId { get; set; }

        public Streetcode Streetcode { get; set; }
        public Partner Partner { get; set; }
    }
}

