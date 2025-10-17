using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
namespace BeetleMovies
{
    public class Director
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        public ICollection<Movie> Movies { get; set; } = [];
        [SetsRequiredMembers]
        public Director()
        {
        }
        public Director(string name, int id)
        {
            Id = id;
            Name = name;
        }
    }
}