using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LossTypeController : ControllerBase
    {
        private readonly LossTypeService _lossTypeService;

        public LossTypeController(LossTypeService lossTypeService)
        {
            _lossTypeService = lossTypeService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetLossType()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                string sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                string sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                string searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                IList<LossType> lossTypes = await _lossTypeService.GetLossType(sortColumn, sortColumnDirection, searchValue);
                recordsTotal = lossTypes.Count();
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = lossTypes.Skip(skip).Take(pageSize) };
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
