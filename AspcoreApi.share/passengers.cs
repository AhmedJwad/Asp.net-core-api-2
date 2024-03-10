using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspcoreApi.share
{
    [Table("passengers")]
    public class passengers
    {
        [Key]
        public int Pass_ID { get; set; }
        public long Pass_PhoneNumber { get; set; }
        public string Pass_Password { get; set; }
        public string Pass_FristName { get; set; }
        public string Pass_SecondName { get; set; }
        public string Pass_LastName { get; set; }
        public int? Pass_GenderM { get; set; }
        public DateTime? Pass_BirthDate { get; set; }
        public short? Pass_Rank { get; set; }
        public byte? Pass_Rating { get; set; }
        public int? Pass_Balance { get; set; }
        public short Pass_Flags { get; set; }
        public byte Pass_Status { get; set; }
        public byte Pass_languge { get; set; }
        public DateTime? email_verified_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? created_at { get; set; }
    }
}
