using System;
using System.Net.Http;

namespace translatorAPI
{
    class Program
    {
        static string endpoint = "https://api.cognitive.microsofttranslator.com";
        static string subscriptionKey = "_____428f95b165ea59_____";
        static string region = "___eastasia___";
        static void Main(string[] args)
        {
            //set up console encoding
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //translate wording
            var words = "Hello World!";
            //show 
            Console.WriteLine(words);
            //call tranlator API
            var ret = MakeTranslator(words);
            //dsiplay
            Console.WriteLine(ret[0].translations[0].text);
        }

        static dynamic MakeTranslator(string msg)
        {
            HttpClient client = new HttpClient();
            string uri = endpoint + "/translate?api-version=3.0&to=ja&to=en&to=ko";

            // Request headers.
            client.DefaultRequestHeaders.Add(
                "Ocp-Apim-Subscription-Key", subscriptionKey);
            client.DefaultRequestHeaders.Add(
           "Ocp-Apim-Subscription-Region", region);

            var JsonString = "[{\"text\" : \"" + msg + "\"}]";
            var content =
               new StringContent(JsonString, System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync(uri, content).Result;
            var JSON=response.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(JSON);
        }
    }
}
