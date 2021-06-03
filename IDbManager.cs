using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplibri
{
   public interface IDbManager
    {
      public  void GetAllLibri();         
        void GetAllLIbriCartacei();      
        void GetAllAudioLIbri();         
        void UpdateCartaceo();      
        void UpdateAudio();         
        void CercaLibro();           
        void AddLibro();            
    }
}
