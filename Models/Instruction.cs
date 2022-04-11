using System;
using System.Collections.Generic;

namespace Models
{
    public class Instruction
    {
        public List<string> messages { get; set; }
        public Instruction()
        {
            messages = new List<string>();
        }
    }
}
