using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocph.DAL;
 
 namespace Penjadwalan.Models 
{ 
     [TableName("aspnetuserlogins")] 
     public class aspnetuserlogins :BaseNotify  
   {
          [PrimaryKey("LoginProvider")] 
          [DbColumn("LoginProvider")] 
          public string LoginProvider 
          { 
               get{return _loginprovider;} 
               set{ 

                    SetProperty(ref _loginprovider, value);
                     }
          } 

          [PrimaryKey("ProviderKey")] 
          [DbColumn("ProviderKey")] 
          public string ProviderKey 
          { 
               get{return _providerkey;} 
               set{ 

                    SetProperty(ref _providerkey, value);
                     }
          } 

          [PrimaryKey("UserId")] 
          [DbColumn("UserId")] 
          public string UserId 
          { 
               get{return _userid;} 
               set{ 

                    SetProperty(ref _userid, value);
                     }
          } 

          private string  _loginprovider;
           private string  _providerkey;
           private string  _userid;
      }
}


