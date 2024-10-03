using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5_2.Models
{
    public class CookieModel
    {
        [Required]
        public string Value { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ExpirationDate { get; set; }
    }
}