using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class AlertDL:IAlertDL
    {
        MyTravelAgentContext myContext;
        public AlertDL(MyTravelAgentContext myContext)
        {
            this.myContext = myContext;
        }

        public async Task<List<Alert>> getAlertsForCalender(DateTime start, DateTime end)
        {
            return await myContext.Alerts.Where(alert=> alert.Date >=start && alert.Date <=end).ToListAsync();
        }

        public async Task<List<Alert>> getRelevantAlerts(DateTime date)
        { 
            return await myContext.Alerts.Where(a => a.Date< date).ToListAsync();
        }
        public async Task<int> insertAlert(Alert newAlert)
        {
            await myContext.Alerts.AddAsync(newAlert);
            myContext.SaveChanges();
            return newAlert.Id;
        }

        public async Task updateAlert(int id,Alert alertToUpdate)
        {
            Alert alert = await myContext.Alerts.FindAsync(id);
            myContext.Entry(alert).CurrentValues.SetValues(alertToUpdate);
            await myContext.SaveChangesAsync();
        }
        public async Task deleteAlert(int id)
        {
          Alert alertToDelete = await myContext.Alerts.FindAsync(id);
            myContext.Alerts.Remove(alertToDelete);
            await myContext.SaveChangesAsync();
        }
    }
}
