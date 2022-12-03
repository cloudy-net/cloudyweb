using System.ComponentModel.DataAnnotations.Schema;

namespace cloudyweb.Models
{
    public class Page
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

    }
}
