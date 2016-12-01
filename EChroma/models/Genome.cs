using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EChroma.models {
    class Genome {

        public List<string> sequence;
        public List<Gene> genes;
        private ChromaParameters parameters;

        public Genome(List<string> sequence, ChromaParameters parameters) {
            this.sequence = sequence;
            this.parameters = parameters;
            genes = parseSequence(sequence, parameters);
        }

        List<Gene> parseSequence(List<string> sequence, ChromaParameters parameters) {
            var nucleos = parseNucleotides(sequence, parameters);
            var genes = parseGenes(nucleos, parameters);
            return genes;
        }

        static List<Nucleotide> parseNucleotides(List<string> sequence, ChromaParameters parameters) {
            var nucleos = new List<Nucleotide>();
            double numNucleos = parameters.paths * parameters.pathProps;

            var valuesPerNucleo = Math.Floor(sequence.Count / numNucleos);
            var leftOvers = sequence.Count - (valuesPerNucleo * numNucleos);

            int i = 0;
            while (nucleos.Count < numNucleos) {
                var n = new List<string>(); //values to pass to new nucleo
                if (i < leftOvers) { //when sequence.Count is greater than valuesPerNucleo
                    while (n.Count < valuesPerNucleo + 1) { //give extra values to the first few nucleotides
                        n.Add(sequence[i]);
                        i++;
                    }
                    nucleos.Add(new Nucleotide(n));
                } else {
                    while (n.Count < valuesPerNucleo) {
                        n.Add(sequence[i]);
                        i++;
                    }
                    nucleos.Add(new Nucleotide(n));
                }
            }

            return nucleos;
        }

        static List<Gene> parseGenes(List<Nucleotide> nucleos, ChromaParameters parameters) {
            var genes = new List<Gene>();
            var nucleoQ = nucleos.ToQueue();
            parameters.paths.times(p => { //for each path
                var n = new List<Nucleotide>(); //to be passed to new Gene
                for (int j = 0; j < parameters.pathProps; j++) {
                    n.Add(nucleoQ.Dequeue());
                }
                genes.Add(new Gene(n));
            });

            return genes;
        }

        public static List<string> RandomSequence(int length) {
            var sequence = new List<string>();
            var letters = "abcdefghijklmnopqrstuvwxyz".chars();

            length.times(i => {
                sequence.Add(letters.random());
            });

            return sequence;
        }

        public static Genome RandomGenome(int length, ChromaParameters parameters) => 
            new Genome(RandomSequence(length), parameters);
    }
}
