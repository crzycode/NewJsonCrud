/*using JsonCrud_demo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Linq.Expressions;

namespace NewJsonCrud.Models.Tables
{
    public static class DB
    {
        public static string DBStore;
        public static string CreateTable;
        public static string database = Directory.GetCurrentDirectory();
        public static string counterval = "0";

        public static dynamic Create()
        {
            string newdb = $@"{database}\{DBStore}\";
            bool check = false;
            if (!Directory.Exists(newdb))
            {
                Directory.CreateDirectory(newdb);
            }
            if (!File.Exists($@"{newdb}TableInfo.json"))
            {
                File.Create($@"{newdb}TableInfo.json").Dispose();
            }
            var TableInfo = File.ReadAllLines($@"{newdb}TableInfo.json").ToList();
            for (int i = 0; i < TableInfo.Count; i++)
            {
                if (TableInfo[i] == CreateTable)
                {
                    check = true;
                    break;
                }
            }
            if (check == false)
            {
                if (!Directory.Exists($@"{newdb}{CreateTable}"))
                {
                    Directory.CreateDirectory($@"{newdb}{CreateTable}");
                }
                if (!File.Exists($@"{newdb}{CreateTable}\{CreateTable}.json"))
                {
                    File.Create($@"{newdb}{CreateTable}\{CreateTable}.json").Dispose();
                }
                if (!File.Exists($@"{newdb}{CreateTable}\JKey.json"))
                {
                    File.Create($@"{newdb}{CreateTable}\JKey.json").Dispose();
                }
                if (!File.Exists($@"{newdb}{CreateTable}\Function.json"))
                {
                    File.Create($@"{newdb}{CreateTable}\Function.json").Dispose();
                }
                if (!File.Exists($@"{newdb}{CreateTable}\Property.json"))
                {
                    File.Create($@"{newdb}{CreateTable}\Property.json").Dispose();
                }
                TableInfo.Insert(0, $@"{CreateTable}");
                File.WriteAllLines($@"{newdb}TableInfo.json", TableInfo.ToArray());
            }
            var line = File.ReadAllLines($@"{newdb}{CreateTable}\{CreateTable}.json").ToList();
            if (line.Count() <= 0)
            {
                File.WriteAllText($@"{newdb}{CreateTable}\{CreateTable}.json", "[\n]");
            }
            return "gh";
        }
        public static dynamic Post(object u)
        {
            string mpath = @"D:\JsonCrud\NewJsonCrud\NewJsonCrud\Models\CrudClass\DataBase.cs";
            var property = File.ReadAllLines($@"{database}\{DBStore}\{CreateTable}\Property.json").ToList();
            if (u != null)
            {
                if (property.Count() <= 0)
                {
                    foreach (var prop in u.GetType().GetProperties())
                    {
                        if (property.Count <= 0)
                        {
                            property.Insert(0, $@"if (json[i].{prop.Name} == numericValue)");
                        }
                        property.Insert(0, $@"json[i].{prop.Name} = u.{prop.Name};");


                        File.WriteAllLines($@"{database}\{DBStore}\{CreateTable}\Property.json", property.ToArray());
                    }

                }
            }
            string Path = $@"{database}\{DBStore}\{CreateTable}\{CreateTable}.json";
            string Key = $@"{database}\{DBStore}\{CreateTable}\JKey.json";
            string lineContents = ReadSpecificLine(2);
            var f = File.ReadAllLines(Path).ToList();
            var ja = JsonConvert.SerializeObject(u, Formatting.Indented);

            f.Insert(1, "," + ja);
            File.WriteAllLines(Path, f);
            return "successs";
        }
        public static dynamic Get()
        {
            string Path = $@"{database}\{DBStore}\{CreateTable}\{CreateTable}.json";
            string Key = $@"{database}\{DBStore}\{CreateTable}\JKey.json";
            string Function = $@"{database}\{DBStore}\{CreateTable}\Function.json";
            string path = @"D:\JsonCrud\NewJsonCrud\NewJsonCrud\Models\CrudClass\DataBase.cs";
            string lineContents = ReadSpecificLine(1);
            dynamic data = File.ReadAllText(Path);
            var func = File.ReadAllLines(Function).ToList();
            if (func.Count() <= 0)
            {
                List<string> list = new List<string>();
                var line = File.ReadAllLines(path).ToList();
                list.Insert(0, $"var json = JsonConvert.DeserializeObject<List<{CreateTable}>>(data);");
                list.Insert(0, $"{CreateTable} u = json[i];");
                File.WriteAllLines(Function, list);
            }


            var line1 = File.ReadAllLines(path).ToList();
            line1.RemoveAt(124);
            line1.Insert(124, $"var json = JsonConvert.DeserializeObject<List<{CreateTable}>>(data);");
            File.WriteAllLines(path, line1);

            var json = JsonConvert.DeserializeObject<List<User>>(data);

            if (json != null)
            {
                var line2 = File.ReadAllLines(path).ToList();
                line2.RemoveAt(135);
                line2.Insert(135, $"{CreateTable} u = json[i];");
                File.WriteAllLines(path, line2);
                for (int i = 0; i < json.Count; i++)
                {

                    User u = json[i];



                }
            }
            return json;
        }
        public static dynamic FindById(string id)
        {
            string Path = $@"{database}\{DBStore}\{CreateTable}\{CreateTable}.json";
            string Key = $@"{database}\{DBStore}\{CreateTable}\JKey.json";
            string cs = @"D:\JsonCrud\NewJsonCrud\NewJsonCrud\Models\CrudClass\DataBase.cs";
            var property = File.ReadAllLines($@"{database}\{DBStore}\{CreateTable}\Property.json").ToList();
            List<dynamic> objectnames = new List<dynamic>();
            dynamic data = File.ReadAllText(Path);
            ReadSpecificLine(1);
            var line = File.ReadAllLines(cs).ToList();
            line.RemoveAt(157);
            line.Insert(157, $"var json = JsonConvert.DeserializeObject<List<{CreateTable}>>(data);");
            File.WriteAllLines(cs, line);

            var json = JsonConvert.DeserializeObject<List<User>>(data);

            int numericValue;
            bool isNumber = int.TryParse(id, out numericValue);
            if (isNumber == true)
            {
                if (json != null)
                {

                    List<string> list = new List<string>();
                    for (int k = 0; k < property.Count; k++)
                    {

                        list.Add(property[k]);

                    }
                    var liscout = list.Count() - 1;

                    var line2 = File.ReadAllLines(cs).ToList();
                    line2.RemoveAt(183);
                    line2.Insert(183, list[liscout]);
                    File.WriteAllLines(cs, line2.ToArray());

                    for (int i = 0; i < json.Count; i++)
                    {

                        if (json[i].U_id == numericValue)

                        {
                            objectnames.Add(json[i]);
                            break;
                        }
                    }
                }
            }
            return objectnames;
        }
        public static dynamic Update(User u, string id)
        {
            string Path = $@"{database}\{DBStore}\{CreateTable}\{CreateTable}.json";
            string Key = $@"{database}\{DBStore}\{CreateTable}\JKey.json";

            string mpath = @"D:\JsonCrud\NewJsonCrud\NewJsonCrud\Models\CrudClass\DataBase.cs";


            var property = File.ReadAllLines($@"{database}\{DBStore}\{CreateTable}\Property.json").ToList();
            dynamic data = File.ReadAllText(Path);
            ReadSpecificLine(1);
            var line1 = File.ReadAllLines(mpath).ToList();
            line1.RemoveAt(210);
            line1.Insert(210, $"var json = JsonConvert.DeserializeObject<List<{CreateTable}>>(data);");
            File.WriteAllLines(mpath, line1);
            var json = JsonConvert.DeserializeObject<List<User>>(data);


            int numericValue;
            bool isNumber = int.TryParse(id, out numericValue);
            if (isNumber == true)
            {
                List<string> list = new List<string>();
                for (int k = 0; k < property.Count; k++)
                {
                    list.Add(property[k]);

                }
                var line = File.ReadAllLines(mpath).ToList();
                for (int j = 0; j < list.Count() - 2; j++)
                {
                    line.Insert(243, list[j]);
                    File.WriteAllLines(mpath, line.ToArray());
                }

                if (json != null)
                {
                    var liscout = list.Count() - 1;
                    var line2 = File.ReadAllLines(mpath).ToList();
                    line2.RemoveAt(239);
                    line2.Insert(239, list[liscout]);
                    File.WriteAllLines(mpath, line2.ToArray());
                    for (int i = 0; i < json.Count; i++)
                    {
                        if (json[i].U_id == numericValue)
                        {







                            string output = JsonConvert.SerializeObject(json, Formatting.Indented);
                            File.WriteAllText(Path, output);
                            for (int m = 0; m < list.Count - 2; m++)
                            {
                                line.RemoveAt(243);
                                File.WriteAllLines(mpath, line.ToArray());
                            }
                            return json[i];

                        }
                    }
                }
            }
            else
            {
                return "invalid id";
            }

            return "hey";
        }

        public static dynamic JKey()
        {

            string Path = $@"{database}\{DBStore}\{CreateTable}\{CreateTable}.json";
            string Key = $@"{database}\{DBStore}\{CreateTable}\JKey.json";
            var line = File.ReadAllLines(Key).ToList();
            if (line.Count <= 0)
            {
                File.WriteAllText(Key, counterval);
            }
            var Inc = File.ReadAllLines(Key).ToList();
            var value = int.Parse(Inc[0]);
            var data = value + 1;
            *//*Inc.Insert(1, data.ToString());*//*
            File.WriteAllText(Key, data.ToString());
            return data;
        }
        public static dynamic ReadSpecificLine(int count)
        {
            string Path = $@"{database}\{DBStore}\{CreateTable}\{CreateTable}.json";
            string Key = $@"{database}\{DBStore}\{CreateTable}\JKey.json";
            if (count == 2)
            {
                var linesList = File.ReadAllLines(Path).ToList();
                if (linesList.Count > 6)
                {
                    linesList.RemoveAt(1);
                    linesList.Insert(1, ",{");
                    File.WriteAllLines(Path, linesList.ToArray());
                }
            }
            else
            {
                var linesList = File.ReadAllLines(Path).ToList();
                if (linesList.Count > 6)
                {
                    linesList.RemoveAt(1);
                    linesList.Insert(1, "{");
                    File.WriteAllLines(Path, linesList.ToArray());
                }
            }
            return "success";
        }
    }
}

*/