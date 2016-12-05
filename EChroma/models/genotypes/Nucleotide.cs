using System;
using System.Collections.Generic;
using System.Linq;

namespace EChroma.models.genotypes {
    public class Nucleotide {
        public double value;
        
        public Nucleotide(List<string> values) {
            value = (from v in values select getLetterIndex(v)).Average()/25;
        }

        int getLetterIndex(string letter) {
            var letters = "abcdefghijklmnopqrstuvwxyz".chars();
            return letters.IndexOf(letter);
        }

    }
}