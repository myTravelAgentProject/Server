using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
   public class HotelDL:IHotelDL
  {
        MyTravelAgentContext myContext;
        public HotelDL(MyTravelAgentContext myContext)
        {
            this.myContext = myContext;
        }
        public async Task<int> addNewHotel(Hotel newHotel)
        {
            await myContext.Hotels.AddAsync(newHotel);
            myContext.SaveChanges();
            return newHotel.Id;
        }

        public async Task<List<Hotel>> GetHotelsList()
        {
            return myContext.Hotels.ToList();
        }
    }
}
