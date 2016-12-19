using Newtonsoft.Json;
using NJsonSchema;
using NJsonSchema.CodeGeneration.TypeScript;
using System;

namespace n_json_schema_getting_started
{
    class Program
    {
        static void Main(string[] args)
        {
            var schema = JsonSchema4.FromType<Person>();            
            var generator = new TypeScriptGenerator(schema);
            var file = generator.GenerateFile();
            Console.Write(file);
            Console.ReadLine();
        }

        public static void InvalidJSON()
        {
            var schema = JsonSchema4.FromType<Person>();
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
