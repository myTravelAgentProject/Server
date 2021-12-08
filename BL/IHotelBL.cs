﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IHotelBL
    {
        public Task<int> addNewHotel(Hotel newHotel);
        public Task<List<Hotel>> GetHotelsList();
        public Task deleteHotel(int id);
    }
}
