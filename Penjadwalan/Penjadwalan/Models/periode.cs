using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocph.DAL;
 
 namespace Penjadwalan.Models 
{ 
     [TableName("periode")] 
     public class periode :BaseNotify  
   {
          [PrimaryKey("idperiode")] 
          [DbColumn("idperiode")] 
          public int idperiode 
          { 
               get{return _idperiode;} 
               set{ 

                    SetProperty(ref _idperiode, value);
                     }
          } 

          [DbColumn("TanggalMulai")] 
          public DateTime TanggalMulai 
          { 
               get{return _tanggalmulai;} 
               set{ 

                    SetProperty(ref _tanggalmulai, value);
                     }
          } 

          [DbColumn("TanggalAkhir")] 
          public DateTime TanggalAkhir 
          { 
               get{return _tanggalakhir;} 
               set{ 

                    SetProperty(ref _tanggalakhir, value);
                     }
          } 

          private int  _idperiode;
           private DateTime  _tanggalmulai;
           private DateTime  _tanggalakhir;
      }
}


