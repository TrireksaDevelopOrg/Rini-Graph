using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocph.DAL;
 
 namespace Penjadwalan.Models 
{ 
     [TableName("perawat")] 
     public class perawat :BaseNotify  
   {
          [PrimaryKey("IdPerawat")] 
          [DbColumn("IdPerawat")] 
          public int IdPerawat 
          { 
               get{return _idperawat;} 
               set{ 

                    SetProperty(ref _idperawat, value);
                     }
          } 

          [DbColumn("Nama")] 
          public string Nama 
          { 
               get{return _nama;} 
               set{ 

                    SetProperty(ref _nama, value);
                     }
          } 

          [DbColumn("NIP")] 
          public string NIP 
          { 
               get{return _nip;} 
               set{ 

                    SetProperty(ref _nip, value);
                     }
          } 

          [DbColumn("Golongan")] 
          public string Golongan 
          { 
               get{return _golongan;} 
               set{ 

                    SetProperty(ref _golongan, value);
                     }
          } 

          [DbColumn("Alamat")] 
          public string Alamat 
          { 
               get{return _alamat;} 
               set{ 

                    SetProperty(ref _alamat, value);
                     }
          } 

          [DbColumn("Gender")] 
          public string Gender 
          { 
               get{return _gender;} 
               set{ 

                    SetProperty(ref _gender, value);
                     }
          } 
        public List<ItemJadwal> Dates { get; set; }
        public List<jadwal> Jadwals { get; internal set; }

        private int  _idperawat;
           private string  _nama;
           private string  _nip;
           private string  _golongan;
           private string  _alamat;
           private string  _gender;
      }



    public class ItemJadwal
    {
        public DateTime Date { get; set; }
        public string Value { get; set; }
    }
}


