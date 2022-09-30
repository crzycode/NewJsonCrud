using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace NewJsonCrud.Models.Tables
{
    public static class merge
    {
        public static dynamic df(Object u)
        {
            var path = @"D:\JsonCrud\NewJsonCrud\NewJsonCrud\JsonCrud\User\User.json";
            var updatepath = String.Format(path, AppDomain.CurrentDomain.BaseDirectory);
            string jsonOldFile = new StreamReader(path).ReadToEnd();

            string path2 = @"D:\JsonCrud\NewJsonCrud\NewJsonCrud\JsonCrud\Employee\Employee.json";
            var updatepath1 = String.Format(path2, AppDomain.CurrentDomain.BaseDirectory);
            string jsonOldFile1 = new StreamReader(path2).ReadToEnd();






            /*var jsonO = JObject.Parse(jsonOldFile);
            var jsonU = JObject.Parse(jsonOldFile1);*/
            var k = @"D:\JsonCrud\NewJsonCrud\NewJsonCrud\JsonCrud\Employee\JKey.json";
            var f = File.ReadAllLines(k).ToList();
            
            
            var ja =JsonConvert.SerializeObject(u, Formatting.Indented);
           
            f.Insert(1, ja);
           

           /* var jsonO = JArray.Parse(jsonOldFile);
            var jsonU = JArray.Parse(jsonOldFile1);*/


            //merge new json into old json
            /*  jsonO.Merge(jsonU);*/


            //save to file
            /*   FileInfo file = new FileInfo(path);
               file.Directory.Create();*/
            /*foreach (JObject innerData in jsonU)
            {
                jsonO.Add(innerData);
            }*/
           
            System.IO.File.WriteAllLines(k, f);
            return "hg";
        }
     

    }
}
