using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EChroma {
    static class ExtensionMethods {

        static Random rand = new Random();

        public static List<int> to(this int min, int max) {
            var range = new List<int>();
            for (int i = min; i < max; i++) {
                range.Add(i);
            }
            return range;
        }

        public static void times(this int t, Action<int> action) {
            foreach(var i in 0.to(t)) {
                action(i);
            }
        }

        public static void each<T>(this List<T> list, Action<T> action) {
            foreach(var t in list) {
                action(t);
            }
        }

        public static void each(this string str, Action<string> action) {
            foreach (var s in str.Split()) {
                action(s);
            }
        }

        public static T random<T>(this List<T> list) {
            return list[rand.Next(list.Count)];
        }

        public static List<string> chars(this string str) {
            var subs = str.Select(c => c.ToString()).ToList();
            return subs;
        }

        public static Queue<T> ToQueue<T>(this List<T> list) {
            var q = new Queue<T>();

            list.ForEach(t => q.Enqueue(t));

            return q;
        }
        
    }
}
