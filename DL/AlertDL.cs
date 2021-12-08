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

        /*(get) returns all the alerts that their date had pass -
         that need to be made*/
        public async Task<List<Alert>> getRelevantAlerts(DateTime date)
        {
            return await myContext.Alerts.Where(a => a.Date < date).ToListAsync();
        }

        /*(post) adds the new alert to the alerts table,
         then save the changes
        returns the id that be accepted from the database after inserting*/
        public async Task<int> insertAlert(Alert newAlert)
        {
            await myContext.Alerts.AddAsync(newAlert);
            myContext.SaveChanges();
            return newAlert.Id;
        }

        /*(put) finds the alert we want to change,
         changes the old alert with the new one that has the changes
        save the changes*/
        public async Task updateAlert(int id, Alert alertToUpdate)
        {
            Alert alert = await myContext.Alerts.FindAsync(id);
            myContext.Entry(alert).CurrentValues.SetValues(alertToUpdate);
            await myContext.SaveChangesAsync();
        }

        /*(delete) finds the alert according to its id
         remove the alert from the table
        save the changes*/
        public async Task deleteAlert(int id)
        {
            Alert alertToDelete = await myContext.Alerts.FindAsync(id);
            myContext.Alerts.Remove(alertToDelete);
            await myContext.SaveChangesAsync();
        }

        /*(getAlerts)(from the calendar controller) returns the alerts between tow dates,
         to show in the calendar the alerts for the month or the week we show*/
        public async Task<List<Alert>> getAlertsForCalender(DateTime start, DateTime end)
        {
            return await myContext.Alerts.Where(alert=> alert.Date >=start && alert.Date <=end).ToListAsync();
        }
    }
}
