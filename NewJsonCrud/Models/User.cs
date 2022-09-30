
using System.Collections.Generic;
using System.Text.Json.Nodes;
using Newtonsoft;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using NewJsonCrud.Models.CrudClass;

namespace JsonCrud_demo.Models
{
    public class User
    {



        public int U_id { get; set; } 
     public string U_Name { get; set;} = string.Empty;
        public string U_Email { get; set; } = string.Empty;
        public int U_Age { get; set; }
        
        public int U_Salary { get; set; }
        public string U_Disignation { get; set; } = string.Empty;

        public PropertyInfo[] GetProperties()
        {
            try
            {
                return this.GetType().GetProperties();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static User SetValue(User obj, string parameterName, object parameterValue)
        {
            try
            {
                obj.GetType().GetProperties().FirstOrDefault(x => x.Name == parameterName).SetValue(obj, parameterValue);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }

 }

