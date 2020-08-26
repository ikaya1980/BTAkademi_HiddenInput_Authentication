using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ornekWeb.Models
{
    public class QuestionAnswer
    {
        public int questionAnswerId { get; set; }
        public int firmId { get; set; }
        public string userName { get; set; }
        public string message { get; set; }
    }
}
