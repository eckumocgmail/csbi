using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace csbi_test_clients_dictionary.Data.Entities
{
    public class CustomerInfo
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string SurName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Tel { get; set; }


        public string GetFullName() => $"{SurName} {FirstName} {LastName}";


        public bool ContainsKeywords(string[] keywords)
        {
            bool result = false;
            foreach (var word in keywords)
            {
                if (word.Length > 0 && this.GetFullName().ToLower().IndexOf(word.Trim().ToLower()) != -1)
                {
                    result = true;
                    break;
                }
            }
            return true;
        }
    }
}
