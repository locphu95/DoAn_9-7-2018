using System.Collections.Generic;
using NguyenPhuLoc.Models;

namespace NguyenPhuLoc.ViewModel
{
    public class Scbnv
    {
       
        public CBNV CB { get; set; }
        public List<Scbnv> UpdateCbnv(CBNV cb, List<Scbnv> list)
        {
            foreach (Scbnv item in list)
            {
                if (item.CB.MaCBNV == cb.MaCBNV)
                {
                  
                }
            }
            return list;  
        }
    }
}