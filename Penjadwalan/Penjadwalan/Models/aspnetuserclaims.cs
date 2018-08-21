using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocph.DAL;
 
 namespace Penjadwalan.Models 
{ 
     [TableName("aspnetuserclaims")] 
     public class aspnetuserclaims :BaseNotify  
   {
          [PrimaryKey("Id")] 
          [DbColumn("Id")] 
          public int Id 
          { 
               get{return _id;} 
               set{ 

                    SetProperty(ref _id, value);
                     }
          } 

          [DbColumn("UserId")] 
          public string UserId 
          { 
               get{return _userid;} 
               set{ 

                    SetProperty(ref _userid, value);
                     }
          } 

          [DbColumn("ClaimType")] 
          public string ClaimType 
          { 
               get{return _claimtype;} 
               set{ 

                    SetProperty(ref _claimtype, value);
                     }
          } 

          [DbColumn("ClaimValue")] 
          public string ClaimValue 
          { 
               get{return _claimvalue;} 
               set{ 

                    SetProperty(ref _claimvalue, value);
                     }
          } 

          private int  _id;
           private string  _userid;
           private string  _claimtype;
           private string  _claimvalue;
      }
}


