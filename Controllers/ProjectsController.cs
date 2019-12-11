using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManageProject.Model;

namespace ManageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectContext _context;

        public ProjectsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ResponseModel<List<ProjectView>>> GetProject([FromQuery]RequestModel model)
        {
            if (ModelState.IsValid)
            {



                var query = _context.Project
                    .Select(x => new ProjectView { Id = x.Id, Name = x.Name, Member = x.MemberName, Description = x.Description,Startdate = x.StartDate,Finishdate = x.EndDate,Bugtest = x.BugList,Buguat = x.BugUav,Pcost = x.PlanCost,Acost = x.ActualCost,Cssscore = x.CssScore,Status = x.Status });
                if (!String.IsNullOrWhiteSpace(model.searchText))
                {
                    query = query.Where(x => x.Name.Contains(model.searchText) /*|| x.Address.Contains(model.searchText) || x.Name.Contains(model.searchText)*/);
                }
                var total = await query.LongCountAsync();
                query = query.Skip(model.size * (model.index - 1)).Take(model.size);
                return new ResponseModel<List<ProjectView>> { Data = await query.ToListAsync(), Paging = new Paging { index = model.index, size = model.size, count = total } };
            }
            return null;

        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectView>> GetStaff(int id)
        {
            var query = await _context.Project.Select(x => new ProjectView { Id = x.Id, Name = x.Name, Member = x.MemberName, Description = x.Description, Startdate = x.StartDate, Finishdate = x.EndDate, Bugtest = x.BugList, Buguat = x.BugUav, Pcost = x.PlanCost, Acost = x.ActualCost, Cssscore = x.CssScore, Status = x.Status }).FirstOrDefaultAsync(x => x.Id == id);

            if (query == null)
            {
                return NotFound();
            }

            return query;
        }

        // PUT: api/Staffs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, ProjectView viewStaff)
        {
            if (id != viewStaff.Id)
            {
                return BadRequest();
            }
            var project = new Project
            {
                Id = viewStaff.Id,
                Name = viewStaff.Name,
                MemberName = viewStaff.Member,
                StartDate = viewStaff.Startdate,
                EndDate = viewStaff.Finishdate,
                BugList = viewStaff.Bugtest,
                BugUav = viewStaff.Buguat,
                PlanCost = viewStaff.Pcost,
                ActualCost = viewStaff.Acost,
                CssScore = viewStaff.Cssscore,
                Description = viewStaff.Description,
                Status = viewStaff.Status

            };
            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Staffs
        [HttpPost]
        public async Task<ActionResult<ProjectView>> PostStaff(ProjectView viewStaff)
        {
            var project = new Project
            {
                Name = viewStaff.Name,
                MemberName = viewStaff.Member,
                StartDate = viewStaff.Startdate,
                EndDate = viewStaff.Finishdate,
                BugList = viewStaff.Bugtest,
                BugUav = viewStaff.Buguat,
                PlanCost = viewStaff.Pcost,
                ActualCost = viewStaff.Acost,
                CssScore = viewStaff.Cssscore,
                Description = viewStaff.Description,
                Status = viewStaff.Status

            };
            _context.Project.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaff", new { id = project.Id }, project);
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteStaff(int id)
        {
            var staff = await _context.Project.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            _context.Project.Remove(staff);
            await _context.SaveChangesAsync();

            return staff;
        }

        private bool StaffExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }
    }
}
