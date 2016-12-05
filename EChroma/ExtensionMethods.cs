using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EChroma.models.genotypes;
using EChroma.models;
using EChroma.models.phenotypes;
using MathNet.Numerics.Interpolation;

namespace EChroma {
    static class ExtensionMethods {

        public static Random rand = new Random();

        public static List<int> to(this int min, int max) {
            var range = new List<int>();
            for (int i = min; i < max; i++) {
                range.Add(i);
            }
            return range;
        }

        public static void times(this int t, Action<int> action) {
            foreach (var i in 0.to(t)) {
                action(i);
            }
        }

        public static void each<T>(this List<T> list, Action<T> action) {
            foreach (var t in list) {
                action(t);
            }
        }

        public static void each(this string str, Action<string> action) {
            foreach (var s in str.Split()) {
                action(s);
            }
        }

        public static T random<T>(this List<T> list) => list[rand.Next(list.Count)];

        public static List<string> chars(this string str) => str.Select(c => c.ToString()).ToList();

        public static Queue<T> ToQueue<T>(this List<T> list) {
            var q = new Queue<T>();

            list.ForEach(t => q.Enqueue(t));

            return q;
        }

        public static string randomChar(this string str) => str.chars().random();

        public static string toJson(this object o) => JsonConvert.SerializeObject(o);


        /// <summary>
        /// Takes the first i elements from a Queue, Dequeueing them in the process, and returning them as a List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="q"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static List<T> Take<T>(this Queue<T> q, int i) {
            var list = new List<T>();

            i.times(_ => list.Add(q.Dequeue()));
            return list;
        }

        /// <summary>
        /// Takes the first i elements from a Queue, Dequeueing them in the process, and returning them as a Queue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="q"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Queue<T> Dequeue<T>(this Queue<T> q, int i) {
            var newQ = new Queue<T>();

            i.times(_ => newQ.Enqueue(q.Dequeue()));
            return newQ;
        }

        public static double lerp(this double t, double a, double b) => (1 - t) * a + t * b;
    }
}
