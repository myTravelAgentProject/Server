using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IAlertBL
    {
        //(get)
        public Task<List<Alert>> getRelevantAlerts(DateTime date);
        //(post)
        public Task<int> insertAlert(Alert newAlert);
        //(put)
        public  Task updateAlert(int id, Alert alertToUpdate);
        //(delete)
        public Task deleteAlert(int id);
        //(getAlerts)(from calendar controller)
        public Task<List<Alert>> getAlertsForCalender(DateTime start, DateTime end);
    }
}
