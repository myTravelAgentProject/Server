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
        MyTravelAgent2Context myContext;
        public HotelDL(MyTravelAgent2Context myContext)
        {
            this.myContext = myContext;
        }

        /*(get) returns a list of all the hotels*/
        public async Task<List<Hotel>> GetHotelsList()
        {
            return myContext.Hotels.ToList();
        }

        /*(post) add the new hotel to the hotel table,
         save the changes
        return the id of the new hotel*/
        public async Task<int> addNewHotel(Hotel newHotel)
        {
            await myContext.Hotels.AddAsync(newHotel);
             await  myContext.SaveChangesAsync();
            return newHotel.Id;
        }

        /*find the index of the hotel we want to erase,
         remove the hotel
        save the changes*/
        public async Task deleteHotel(int id)
        {
            Hotel HoteltoDelete = await myContext.Hotels.FindAsync(id);
            myContext.Hotels.Remove(HoteltoDelete);
            await myContext.SaveChangesAsync();
        }  
    }
}
