using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_6
{
    public class Enrollment
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }

        public virtual Course Course { get; set; }

    }
}
