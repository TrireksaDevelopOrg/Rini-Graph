using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocph.DAL;
 
 namespace Penjadwalan.Models 
{ 
     [TableName("aspnetuserroles")] 
     public class aspnetuserroles :BaseNotify  
   {
          [PrimaryKey("UserId")] 
          [DbColumn("UserId")] 
          public string UserId 
          { 
               get{return _userid;} 
               set{ 

                    SetProperty(ref _userid, value);
                     }
          } 

          [PrimaryKey("RoleId")] 
          [DbColumn("RoleId")] 
          public string RoleId 
          { 
               get{return _roleid;} 
               set{ 

                    SetProperty(ref _roleid, value);
                     }
          } 

          private string  _userid;
           private string  _roleid;
      }
}


