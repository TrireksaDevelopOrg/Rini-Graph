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

          [DbColumn("Bulan")] 
          public int Bulan 
          { 
               get{return _tanggalmulai;} 
               set{ 

                    SetProperty(ref _tanggalmulai, value);
                     }
          } 

          [DbColumn("Tahun")] 
          public int Tahun 
          { 
               get{return _tanggalakhir;} 
               set{ 

                    SetProperty(ref _tanggalakhir, value);
                     }
          } 

          private int  _idperiode;
           private int  _tanggalmulai;
           private int  _tanggalakhir;
      }
}


