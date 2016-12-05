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
using EChroma.models.genotypes;

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
                                r.Respond(200, new Dictionary<string, string> {
                                    {"genome", genome.toJson() }
                                });
                            });
                    });

                requests.POST("painting")
                    .Subscribe(r => {
                        r.Request.GetBody()
                        .Subscribe(body => {
                            try {
                                var input = JsonConvert.DeserializeObject<PaintingInput>(body);
                                Console.WriteLine($"POST: Props required: {input.parameters.propsRequired} , {input.sequence.Length} sequence");

                                if (input.parameters.propsRequired > input.sequence.Length)
                                    throw new ShortSequenceException(input.parameters.propsRequired, input.sequence.Length);

                                var genome = new Genome(input.sequence, input.parameters);
                                r.Respond(genome.toPainting().toJson(), 200);
                            } catch (ShortSequenceException e) {
                                Console.WriteLine(e);
                                r.Respond(new Dictionary<string, string> { { "error", e.Message } }.toJson(), 400);
                            }

                        });
                    });

                Console.ReadLine();
            }
        }
    }
}
