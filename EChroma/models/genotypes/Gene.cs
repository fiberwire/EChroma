using EChroma.models.phenotypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EChroma.models.genotypes {
    class Gene {
        public List<Nucleotide> nucleotides;

        public Gene(List<Nucleotide> nucleotides) {
            this.nucleotides = nucleotides;
        }

        public Tuple<Path, Paint> Interpret(ChromaParameters parameters) {
            var nq = nucleotides.ToQueue();
            var path = getPath(nq.Dequeue(parameters.propsPerCurve*parameters.curves), parameters);
            var paint = getPaint(nq.Dequeue(parameters.propsPerPaint), parameters);

            return new Tuple<Path, Paint>(path, paint);
        }

        Path getPath(Queue<Nucleotide> nq, ChromaParameters parameters) {
            var path = new Path();

            while (path.curves.Count < parameters.curves) {
                var curve = parameters.getCurve(nq.Dequeue(parameters.propsPerCurve));
                path.curves.Add(curve);
            }

            return path;
        }

        Paint getPaint(Queue<Nucleotide> nq, ChromaParameters parameters) {
            var paint = new Paint();

            //set paint properties
            paint.style = parameters.getStyle(nq.Dequeue());
            paint.argb = parameters.getARGB(nq.Dequeue(4));
            paint.strokeWidth = parameters.getStrokeWidth(nq.Dequeue());


            return paint;
        }

    }
}
