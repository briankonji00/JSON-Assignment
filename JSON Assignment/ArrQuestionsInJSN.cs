using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_Assignment
{
    internal class ArrQuestionsInJSN
    {
        public  string question { get; set; } 
        public List<string> options { get; set; } 
        public string answer {  get; set; }
        public string correct_feadback { get; set; }
        public string wrong_feadback { get; set; }

    }
}
