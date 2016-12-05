using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EChroma.models.phenotypes {
    class Curve {
        public Point control1, control2, end;

        public Curve(Point c1, Point c2, Point e) {
            control1 = c1;
            control2 = c2;
            end = e;
        }
    }
}
