using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FetchAndStore.Models
{
    public class Response
    {
        [Key]
        public int ResponseID { get; set; }

        [Required]
        public string MethodUsed { get; set; }

        [Required]
        public string UserURL { get; set; }

        [Required]
        public int StatusCode { get; set; }

        [Required]
        public string ResponseTime { get; set; }
    }
}