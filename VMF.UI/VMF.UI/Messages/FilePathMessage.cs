using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMF.UI.Messages
{
    public class FilePathMessage
    {
        public string Path { get; set; }

        public bool IsInput { get; set; }

        public FilePathMessage(string Path, bool IsInput)
        {
            this.Path = Path;
            this.IsInput = IsInput;
        }
    }
}
