using Newtonsoft.Json;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;
using NJsonSchema.CodeGeneration.TypeScript;
using System;
using System.Reflection;
using System.Linq;
using NJsonSchema.Generation;

namespace n_json_schema_getting_started
{
    class Program
    {
        static void Main(string[] args)
        {
            var lib = Assembly.GetExecutingAssembly();

            foreach (Type type in lib.GetTypes().Where(t=>t.Name != "Program" && t.Name.Contains("<>") == false))
            {
                Console.WriteLine(type.Name);
                var schema = JsonSchema4.FromType(type, new JsonSchemaGeneratorSettings
                {
                    DefaultPropertyNameHandling = PropertyNameHandling.CamelCase
                });

                var tsGenerator = new TypeScriptGenerator(schema, new TypeScriptGeneratorSettings { TypeStyle = TypeScriptTypeStyle.Interface  });
                var file = tsGenerator.GenerateFile();
                Console.Write(file);
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        public static void BasicScenario() {
            var schema = JsonSchema4.FromType<PhotoGallery>();
            var generator = new TypeScriptGenerator(schema);
            var csGenerator = new CSharpGenerator(schema);
            var file = generator.GenerateFile();
            Console.Write(file);

            file = csGenerator.GenerateFile();
            Console.Write(file);

            Console.ReadLine();
        }

        public static void InvalidJSON()
        {
            var schema = JsonSchema4.FromType<PhotoGallery>();
            var schemaData = schema.ToJson();
            var invalidJSON = JsonConvert.SerializeObject(new { FirstName = "Quinn" });
            var errors = schema.Validate(invalidJSON);

            foreach (var error in errors)
                Console.WriteLine(error.Path + ": " + error.Kind);

            schema = JsonSchema4.FromJson(schemaData);
            Console.ReadLine();
        }
    }
}
