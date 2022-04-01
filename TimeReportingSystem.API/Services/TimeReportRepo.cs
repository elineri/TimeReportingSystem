﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeReportingSystem.API.Model;
using TimeReportingSystem.Models;

namespace TimeReportingSystem.API.Services
{
    public class TimeReportRepo : ITimeReport<TimeReport>
    {
        private TimeReportDbContext _timeReportContext;

        public TimeReportRepo(TimeReportDbContext timeReportContext)
        {
            _timeReportContext = timeReportContext;
        }
        public async Task<TimeReport> Add(TimeReport newEntity)
        {
            var result = await _timeReportContext.TimeReports.AddAsync(newEntity);
            await _timeReportContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TimeReport> Delete(int id)
        {
            var toDelete = await _timeReportContext.TimeReports.FirstOrDefaultAsync(t => t.TimeReportId == id);
            if (toDelete != null)
            {
                var result = _timeReportContext.TimeReports.Remove(toDelete);
                await _timeReportContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<IEnumerable<TimeReport>> GetAll()
        {
            return await _timeReportContext.TimeReports.ToListAsync();
        }

        public async Task<TimeReport> GetSingle(int id)
        {
            return await _timeReportContext.TimeReports.FirstOrDefaultAsync(t => t.TimeReportId == id);
        }

        public Task<TimeReport> EmployeeReportedTime(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TimeReport> Update(TimeReport Entity)
        {
            var toUpdate = await _timeReportContext.TimeReports.FirstOrDefaultAsync(t => t.TimeReportId == Entity.TimeReportId);
            if (toUpdate != null)
            {
                toUpdate.EmployeeId = Entity.EmployeeId;
                toUpdate.ProjectId = Entity.ProjectId;
                toUpdate.Date = Entity.Date;
                toUpdate.WorkedHours = Entity.WorkedHours;
                toUpdate.Note = Entity.Note;

                await _timeReportContext.SaveChangesAsync();
                return toUpdate;
            }
            return null;
        }

        public Task<IEnumerable<TimeReport>> ProjectEmployees(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TimeReport> EmployeeReportedTimeWeek(int id, int year, int weekNumber)
        {
            throw new NotImplementedException();
        }
    }
}
