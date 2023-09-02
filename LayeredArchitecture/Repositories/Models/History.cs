using System.ComponentModel.DataAnnotations.Schema;

namespace LayeredArchitecture.Repositories.Models
{
    public class History
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Owner { get; set; }
        public required string RepositoryName { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}