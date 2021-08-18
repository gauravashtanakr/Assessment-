using DAL.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LossTypeService
    {
        private readonly InterviewContext _interviewContext;
        private readonly ILogger<LossTypeService> _logger;

        public LossTypeService(InterviewContext interviewContext, ILogger<LossTypeService> logger)
        {
            _interviewContext = interviewContext ?? throw new ArgumentNullException(nameof(interviewContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IList<LossType>> GetLossType(string sortColumn, string sortColumnDirection, string searchValue)
        {
            var searchBy = searchValue;
            var orderCriteria = string.Empty;
            var orderAscendingDirection = true;
            var lossTypes= _interviewContext.LossTypes;
            if (!string.IsNullOrEmpty(sortColumn))
            {
                orderCriteria = sortColumn;
                orderAscendingDirection = sortColumnDirection.ToLower() == "asc";
            }
            else
            {
                orderCriteria = "Id";
                orderAscendingDirection = true;
            }

            var result = await Task.Run(()=> lossTypes.AsEnumerable());

            if (!string.IsNullOrEmpty(searchBy))
            {
                result = result.Where(r => r.LossTypeId.ToString().Contains(searchBy) ||
                                           (r.LossTypeCode != null && r.LossTypeCode.ToUpper().Contains(searchBy.ToUpper())) ||
                                           (r.LossTypeDescription != null && r.LossTypeDescription.ToUpper().Contains(searchBy.ToUpper())))
                    .ToList();
            }
            
            result = orderAscendingDirection ? result.AsQueryable().OrderByDynamic(orderCriteria, DtOrderDir.Asc).ToList() : result.AsQueryable().OrderByDynamic(orderCriteria, DtOrderDir.Desc).ToList();

            return await Task.Run(() => result.ToList());
        }
    }
}
