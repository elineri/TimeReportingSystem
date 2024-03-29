﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeReportingSystem.API.Services
{
    public interface ITimeReport<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int id);
        Task<T> Add(T newEntity);
        Task<T> Update(T Entity);
        Task<T> Delete(int id);
        Task<T> EmployeeReportedTime(int id);
        Task<IEnumerable<T>> ProjectEmployees(int id);
        Task<int> EmployeeReportedTimeWeek(int id, int year, int weekNumber);
    }
}
