using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EChroma.models.phenotypes {
    class Paint {
        public enum Style { Fill, Stroke, FillAndStroke }

        public Style style;
        public List<int> argb;
        public double strokeWidth;
    }
}
