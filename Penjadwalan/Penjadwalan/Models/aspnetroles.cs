using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocph.DAL;
 
 namespace Penjadwalan.Models 
{ 
     [TableName("aspnetroles")] 
     public class aspnetroles :BaseNotify  
   {
          [PrimaryKey("Id")] 
          [DbColumn("Id")] 
          public string Id 
          { 
               get{return _id;} 
               set{ 

                    SetProperty(ref _id, value);
                     }
          } 

          [DbColumn("Name")] 
          public string Name 
          { 
               get{return _name;} 
               set{ 

                    SetProperty(ref _name, value);
                     }
          } 

          private string  _id;
           private string  _name;
      }
}


