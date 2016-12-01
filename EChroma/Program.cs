using EChroma.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EChroma {
    class Program {
        static void Main(string[] args) {
            var parameters = new ChromaParameters {
                paths = 20,
                pathProps = 2
            };
            var sequence = Genome.RandomSequence(parameters.paths * parameters.pathProps);

            var genome = new Genome(sequence, parameters);
        }
    }
}
