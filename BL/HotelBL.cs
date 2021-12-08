using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class HotelBL:IHotelBL
    {
        IHotelDL hotelDL;
        public HotelBL(IHotelDL hotelDL)
        {
            this.hotelDL = hotelDL;
        }
        public async Task<int> addNewHotel(Hotel newHotel)
        {
            return await hotelDL.addNewHotel(newHotel);
        }

        public async Task deleteHotel(int id)
        {
           await hotelDL.deleteHotel(id);
        }

        public async Task<List<Hotel>> GetHotelsList()
        {
           return await hotelDL.GetHotelsList() ;
        }
    }
}
