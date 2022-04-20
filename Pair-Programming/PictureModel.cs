using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pair_Programming
{
    public class PictureModel
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public PictureModel(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}
