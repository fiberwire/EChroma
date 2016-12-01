using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EChroma.models {
    class Gene {
        public List<Nucleotide> nucleotides;

        public Gene(List<Nucleotide> nucleotides) {
            this.nucleotides = nucleotides;
        }
    }
}
