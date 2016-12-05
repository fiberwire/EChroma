using EChroma.models.genotypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EChroma.models.phenotypes {
    class Painting {
        public List<Path> paths;
        public List<Paint> paints;

        public Painting(List<Gene> genes, ChromaParameters parameters) {
            var tuples = (from g in genes select g.Interpret(parameters)).ToList();
            paths = (from t in tuples select t.Item1).ToList();
            paints = (from t in tuples select t.Item2).ToList();
        }

        
    }
}
