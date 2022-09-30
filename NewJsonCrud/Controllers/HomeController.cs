using JsonCrud_demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Text.Json;
using System.IO;
using JsonCrud_demo.Models.CrudClass;
using NewJsonCrud.Models.CrudClass;
using Microsoft.AspNetCore.Hosting.Server;
using Grpc.Core;
using NewJsonCrud.Models;
using NewJsonCrud.Models.Tables;

namespace JsonCrud_demo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]


    public class HomeController : ControllerBase
    {

        


        [HttpPost]
        public dynamic Adduser(User u ){
            DB.DBStore = "JsonCrud";
            DB.CreateTable = "User";
            DB.Create();
            u.U_id = DB.JKey();
            DB.Post(u);


            return "ll";
        }
        [HttpGet]
        public dynamic getdata()
        {
            DB.DBStore = "JsonCrud";
            DB.CreateTable = "User";
            var data = DB.Get();
            return data;
        }
        [HttpGet("{id}")]
        public dynamic finddata(string id)
        {
            DB.DBStore = "JsonCrud";
            DB.CreateTable = "User";
            var data =DB.FindById(id);
            return data;
        }
        [HttpPut("{id}")]
        public dynamic updatedata(User u,string id)
        {
           DB.DBStore = "JsonCrud";
           DB.CreateTable = "User";
            var data = DB.Update(u,id);


            return data;
        }
       
    }
}
