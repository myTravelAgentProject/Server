using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IHotelBL
    {
        //(get)
        public Task<List<Hotel>> GetHotelsList();
        //(post)
        public Task<int> addNewHotel(Hotel newHotel);
        //(delete)
        public Task deleteHotel(int id);
    }
}
