using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocph.DAL;
 
 namespace Penjadwalan.Models 
{ 
     [TableName("matrix")] 
     public class matrix :BaseNotify  
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

          [DbColumn("IdPeriode")] 
          public int IdPeriode 
          { 
               get{return _idperiode;} 
               set{ 

                    SetProperty(ref _idperiode, value);
                     }
          } 

          [DbColumn("Kolom")] 
          public int Kolom 
          { 
               get{return _kolom;} 
               set{ 

                    SetProperty(ref _kolom, value);
                     }
          } 

          [DbColumn("Baris")] 
          public int Baris 
          { 
               get{return _baris;} 
               set{ 

                    SetProperty(ref _baris, value);
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


        private int nilai;
        [DbColumn("Nilai")]
        public int Nilai
        {
            get { return nilai; }
            set { SetProperty(ref nilai ,value); }
        }


        private int  _id;
           private int  _idperiode;
           private int  _kolom;
           private int  _baris;
           private string  _nama;
      }
}


