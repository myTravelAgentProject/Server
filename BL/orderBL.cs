using DL;
using System;
using Entity;

namespace BL
{
    public class orderBL : IOrderBL
    {
        IOrderDL orderDL;
        public orderBL(IOrderDL orderDL)
        {
         
        }
    }
}
