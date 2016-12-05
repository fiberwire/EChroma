using EChroma.models.genotypes;
using EChroma.models.phenotypes;
using System;
using System.Collections.Generic;
using static EChroma.models.phenotypes.Paint;

namespace EChroma.models {
    internal class ChromaParameters {

        public int propsRequired => propsPerPath * paths;
        public int propsPerPath => curves * propsPerCurve + propsPerPaint;
        public int propsPerPaint = 6;
        public int propsPerCurve = 6;

        //painting properties
        public int paths;
        public int curves;
        public int randomLength;
        public int width, height;

        //style properties
        public double minStrokeAlpha, maxStrokeAlpha;
        public double minStrokeRed, maxStrokeRed;
        public double minStrokeGreen, maxStrokeGreen;
        public double minStrokeBlue, maxStrokeBlue;

        public double minStrokeWidth, maxStrokeWidth;

        //curve properties
        public double minX, maxX;
        public double minY, maxY;

        public double getX(double value) => value.lerp(minX, maxX);
        public double getY(double value) => value.lerp(minY, maxY);

        public Curve getCurve(Queue<Nucleotide> nq) {
            var c1 = new Point(
                    getX(nq.Dequeue().value),
                    getY(nq.Dequeue().value)
                    );
            var c2 = new Point(
                    getX(nq.Dequeue().value),
                    getY(nq.Dequeue().value)
                    );

            var end = new Point(
                    getX(nq.Dequeue().value),
                    getY(nq.Dequeue().value)
                    );

            return new Curve(c1, c2, end);
        }

        internal double getStrokeWidth(Nucleotide nucleotide) => nucleotide.value.lerp(minStrokeWidth, maxStrokeWidth);

        internal List<int> getARGB(Queue<Nucleotide> nq) {
            var argb = new List<int>();
            argb.Add(getAlpha(nq.Dequeue()));
            argb.Add(getRed(nq.Dequeue()));
            argb.Add(getGreen(nq.Dequeue()));
            argb.Add(getBlue(nq.Dequeue()));

            return argb;
        }

        private int getBlue(Nucleotide nucleotide) => (int)Math.Floor(nucleotide.value.lerp(minStrokeBlue, maxStrokeBlue));

        private int getGreen(Nucleotide nucleotide) => (int)Math.Floor(nucleotide.value.lerp(minStrokeGreen, maxStrokeGreen));

        private int getRed(Nucleotide nucleotide) => (int)Math.Floor(nucleotide.value.lerp(minStrokeRed, maxStrokeRed));

        private int getAlpha(Nucleotide nucleotide) => (int)Math.Floor(nucleotide.value.lerp(minStrokeAlpha, maxStrokeAlpha));

        public Style getStyle(Nucleotide nuc) {
            var index = nuc.value.lerp(0, Enum.GetValues(typeof(Style)).Length - 1);

            foreach (Style style in Enum.GetValues(typeof(Style))) {
                if ((int)style == Math.Floor(index)) {
                    return style;
                }
            }

            if (nuc.value <= .33) {
                return Style.FillAndStroke;
            } else if (nuc.value <= .66 && nuc.value >= .34) {
                return Style.Fill;
            } else {
                return Style.Stroke;
            }
        }
    }
}