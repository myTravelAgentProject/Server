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

        //(get)
        public async Task<List<Hotel>> GetHotelsList()
        {
           return await hotelDL.GetHotelsList() ;
        }

        //(post)
        public async Task<int> addNewHotel(Hotel newHotel)
        {
            return await hotelDL.addNewHotel(newHotel);
        }

        //(delete)
        public async Task deleteHotel(int id)
        {
           await hotelDL.deleteHotel(id);
        } 
    }
}
