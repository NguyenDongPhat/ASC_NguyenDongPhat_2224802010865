using ASC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ASC.Utilities;
namespace ASC.Model.Queries
{
    public static class Queries
    {
        // 1 reference | 0 changes | 0 authors, 0 changes
        public static Expression<Func<ServiceRequest, bool>> GetDashboardQuery(DateTime? requestedDate,
            List<string> status = null,
            string email = "",
            string serviceEngineerEmail = "")
        {
            var query = (Expression<Func<ServiceRequest, bool>>)(u => true);

            // Add Requested Date Clause
            if (requestedDate.HasValue)
            {
                var requestedDateFilter = (Expression<Func<ServiceRequest, bool>>)(u => u.RequestedDate >= requestedDate);
                query = query.And(requestedDateFilter);
            }

            // Add Email clause if email is passed as a parameter
            if (!string.IsNullOrEmpty(email))
            {
                var requestedDateFilter = (Expression<Func<ServiceRequest, bool>>)(u => u.PartitionKey == email);
                query = query.And(requestedDateFilter);
            }

            // Add Service Engineer Email clause if email is passed as a parameter
            if (!string.IsNullOrEmpty(serviceEngineerEmail))
            {
                var requestedDateFilter = (Expression<Func<ServiceRequest, bool>>)(u => u.ServiceEngineer == serviceEngineerEmail);
                query = query.And(requestedDateFilter);
            }

            // Add Status clause if status is passed a parameter.
            // Individual status clauses are appended with OR Condition
            var statusQueries = (Expression<Func<ServiceRequest, bool>>)(u => false);
            if (status != null)
            {
                foreach (var state in status)
                {
                    var statusFilter = (Expression<Func<ServiceRequest, bool>>)(u => u.Status == state);
                    statusQueries = statusQueries.Or(statusFilter);
                }

                query = query.And(statusQueries);
            }

            return query;
        }
    }
}
