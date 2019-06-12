using System.ComponentModel.DataAnnotations;

namespace NotADog{
    public class StorageAccountOptions
    {
        [Required]
        public string ConnectionString { get; set; }
    }
}