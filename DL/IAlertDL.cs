﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IAlertDL
    {
        public Task<List<Alert>> getRelevantAlerts(DateTime date);
        public Task<int> insertAlert(Alert newAlert);
        public Task updateAlert(int id, Alert alertToUpdate);
        public Task<List<Alert>> getAlertsForCalender(DateTime start, DateTime end);
        public Task deleteAlert(int id);

    }
}
