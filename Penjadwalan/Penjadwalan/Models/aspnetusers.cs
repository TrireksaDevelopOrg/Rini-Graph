using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocph.DAL;
 
 namespace Penjadwalan.Models 
{ 
     [TableName("aspnetusers")] 
     public class aspnetusers :BaseNotify  
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

          [DbColumn("Email")] 
          public string Email 
          { 
               get{return _email;} 
               set{ 

                    SetProperty(ref _email, value);
                     }
          } 

          [DbColumn("EmailConfirmed")] 
          public 0 EmailConfirmed 
          { 
               get{return _emailconfirmed;} 
               set{ 

                    SetProperty(ref _emailconfirmed, value);
                     }
          } 

          [DbColumn("PasswordHash")] 
          public string PasswordHash 
          { 
               get{return _passwordhash;} 
               set{ 

                    SetProperty(ref _passwordhash, value);
                     }
          } 

          [DbColumn("SecurityStamp")] 
          public string SecurityStamp 
          { 
               get{return _securitystamp;} 
               set{ 

                    SetProperty(ref _securitystamp, value);
                     }
          } 

          [DbColumn("PhoneNumber")] 
          public string PhoneNumber 
          { 
               get{return _phonenumber;} 
               set{ 

                    SetProperty(ref _phonenumber, value);
                     }
          } 

          [DbColumn("PhoneNumberConfirmed")] 
          public 0 PhoneNumberConfirmed 
          { 
               get{return _phonenumberconfirmed;} 
               set{ 

                    SetProperty(ref _phonenumberconfirmed, value);
                     }
          } 

          [DbColumn("TwoFactorEnabled")] 
          public 0 TwoFactorEnabled 
          { 
               get{return _twofactorenabled;} 
               set{ 

                    SetProperty(ref _twofactorenabled, value);
                     }
          } 

          [DbColumn("LockoutEndDateUtc")] 
          public DateTime LockoutEndDateUtc 
          { 
               get{return _lockoutenddateutc;} 
               set{ 

                    SetProperty(ref _lockoutenddateutc, value);
                     }
          } 

          [DbColumn("LockoutEnabled")] 
          public 0 LockoutEnabled 
          { 
               get{return _lockoutenabled;} 
               set{ 

                    SetProperty(ref _lockoutenabled, value);
                     }
          } 

          [DbColumn("AccessFailedCount")] 
          public int AccessFailedCount 
          { 
               get{return _accessfailedcount;} 
               set{ 

                    SetProperty(ref _accessfailedcount, value);
                     }
          } 

          [DbColumn("UserName")] 
          public string UserName 
          { 
               get{return _username;} 
               set{ 

                    SetProperty(ref _username, value);
                     }
          } 

          private string  _id;
           private string  _email;
           private 0  _emailconfirmed;
           private string  _passwordhash;
           private string  _securitystamp;
           private string  _phonenumber;
           private 0  _phonenumberconfirmed;
           private 0  _twofactorenabled;
           private DateTime  _lockoutenddateutc;
           private 0  _lockoutenabled;
           private int  _accessfailedcount;
           private string  _username;
      }
}


