using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocph.DAL;
 
 namespace Penjadwalan.Models 
{ 
     [TableName("jadwal")] 
     public class jadwal :BaseNotify  
   {
          [PrimaryKey("IdJadwal")] 
          [DbColumn("IdJadwal")] 
          public int IdJadwal 
          { 
               get{return _idjadwal;} 
               set{ 

                    SetProperty(ref _idjadwal, value);
                     }
          } 

          [DbColumn("Shif")] 
          public string Shif 
          { 
               get{return _shif;} 
               set{ 

                    SetProperty(ref _shif, value);
                     }
          } 

          [DbColumn("Tanggal")] 
          public DateTime Tanggal 
          { 
               get{return _tanggal;} 
               set{ 

                    SetProperty(ref _tanggal, value);
                     }
          } 

          [DbColumn("IdPerawat")] 
          public int IdPerawat 
          { 
               get{return _idperawat;} 
               set{ 

                    SetProperty(ref _idperawat, value);
                     }
          } 

          [DbColumn("IdPeriode")] 
          public int IdPeriode 
          { 
               get{return _idperiode;} 
               set{ 

                    SetProperty(ref _idperiode, value);
                     }
          } 

          private int  _idjadwal;
           private string  _shif;
           private DateTime  _tanggal;
           private int  _idperawat;
           private int  _idperiode;
      }
}


