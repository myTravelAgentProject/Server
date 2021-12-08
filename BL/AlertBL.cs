using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlertBL : IAlertBL
    {
        public IAlertDL alertDL;
        public AlertBL(IAlertDL alertDL)
        {
            this.alertDL = alertDL;
        }

        //(get)
        public async Task<List<Alert>> getRelevantAlerts(DateTime date)
        {
            return await alertDL.getRelevantAlerts(date);
        }

        //(post)
        public async Task<int> insertAlert(Alert newAlert)
        {
            return await alertDL.insertAlert(newAlert);
        }

        //(put)
        public async Task updateAlert(int id, Alert alertToUpdate)
        {
            await alertDL.updateAlert(id, alertToUpdate);
        }

        //(delete)
        public async Task deleteAlert(int id)
        {
           await alertDL.deleteAlert(id);
        }

        //(getAlerts)(from calendar controller)
        public async Task<List<Alert>> getAlertsForCalender(DateTime start, DateTime end)
        {
            return await alertDL.getAlertsForCalender(start, end);
        }
    }
}
