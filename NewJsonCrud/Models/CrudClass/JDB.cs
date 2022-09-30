using System.Collections;


namespace JsonCrud_demo.Models.CrudClass
{
    public class JDB
    {

        public string database;
       
        
        public dynamic CreateJDatabase()
        {
            string DBStore = @"D:\json\" + database + @"\";
            if (!Directory.Exists(DBStore))
            {
                Directory.CreateDirectory(DBStore);
            }
            return DBStore;
        }
        public dynamic CreateJTable(string[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                var d = tab[i];
            }
            
            var store = CreateJDatabase();
            for (int i = 0; i < tab.Length; i++)
            {
                if (!Directory.Exists($@"{store}{tab[i]}"))
                {
                    Directory.CreateDirectory($@"{store}{tab[i]}");
                }
            }
            for (int i = 0; i < tab.Length; i++)
            {
                if (!File.Exists($@"{store}{tab[i]}\{tab[i]}.json"))
                {
                    File.Create($@"{store}{tab[i]}\{tab[i]}.json").Dispose();
                }
                if (!System.IO.File.Exists($@"{store}{tab[i]}\JKey.json"))
                {
                    System.IO.File.Create($@"{store}{tab[i]}\JKey.json").Dispose();
                }
            }
            for (int i = 0; i < tab.Length; i++)
            {
                var line = File.ReadAllLines($@"{store}{tab[i]}\{tab[i]}.json").ToList();
                if (line.Count() <= 0)
                {
                    System.IO.File.WriteAllText($@"{store}{tab[i]}\{tab[i]}.json", "[\n]");
                }
            }

            return "ha";
        }

        public dynamic JTables(string[] tab)
        {
           
            var store = CreateJDatabase();
            List<string> termsList = new List<string>();

            for (int i = 0; i < tab.Length; i++)
            {
                termsList.Add($@"{store}{tab[i]}\{tab[i]}.json");
                
                termsList.Add($@"{store}{tab[i]}\JKey.json");
            }
            string[] itemobj = termsList.Cast<string>().ToArray();
            termsList.AddRange(itemobj);

            

            return termsList;

        }
    }
}
