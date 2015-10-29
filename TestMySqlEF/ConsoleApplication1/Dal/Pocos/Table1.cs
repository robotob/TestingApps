using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Dal.Pocos
{

    [Table("Table1")]
    public class Table1
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        public DateTime ActionDate { get; set; }
    }
}
