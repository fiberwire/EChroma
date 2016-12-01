using Anna;
using EChroma.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;
using Newtonsoft.Json;

namespace EChroma {
    class Program {
        static void Main(string[] args) {
            ChromaParameters parameters;

            using (var requests = new HttpServer("http://*:8000/")) {
                requests.POST("genome/random")
                    .Subscribe(r => {
                        r.Request.GetBody()
                            .Subscribe(body => {
                                parameters = JsonConvert.DeserializeObject<ChromaParameters>(body);
                                var genome = Genome.RandomGenome(parameters.randomLength, parameters);
                                r.Respond(201, new Dictionary<string, string> {
                                    {"genome", genome.toJson() }
                                });
                            });
                    });
                Console.ReadLine();
            }


        }
    }
}
