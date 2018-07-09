using System.Collections.Generic;
using NguyenPhuLoc.Models;

namespace NguyenPhuLoc.ViewModel
{
    public class listCv
    {
        public float isotietchuan {get;set;}
        public int Quantity { get; set; }
        public CongViec CV { get; set; }
        public List<listCv> UpdateOneCartItem(CongViec cv, List<listCv> list)
        {
            foreach (listCv item in list)
            {
                if (item.CV.MaCongViec == cv.MaCongViec)
                {
                   
                    item.Quantity++;
                    return list;
                }
            }
            list.Add(new listCv()
            {
                Quantity = 1,
                CV = cv
            });
            return list;
        }
        public int CountTourOnCart(List<listCv> list)
        {
            if (list == null) return 0;
            int res = 0;
            foreach (listCv item in list)
            {
                res += item.Quantity;
            }
            return res;
        }
        public decimal TotalPayCart(List<listCv> list)
        {
            if (list == null) return 0;
            int res = 0;
            foreach (listCv item in list)
            {
                
            }
            return res;
        }
    }

}