namespace Iau.NotifCenter.DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        public int Id { get; set; }

        [StringLength(40)]
        public string Title { get; set; }

        [StringLength(150)]
        public string Body { get; set; }

        public DateTime? SubmitDateTime { get; set; }

        public int? SenderId { get; set; }

        public bool? IsUrgent { get; set; }

        public DateTime? LastModifiedDateTime { get; set; }

        public virtual User User { get; set; }
    }
}
