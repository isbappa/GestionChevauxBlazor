using GestionChevauxBlazor.Data;
using GestionChevauxBlazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionChevauxBlazor.Services
{
    public interface IAjoutProgrammeService
    {
        Task<List<AjoutPlanningReprisesModel>> Get();
        Task<AjoutPlanningReprisesModel> Get(int id);
        Task<AjoutPlanningReprisesModel> Add(AjoutPlanningReprisesModel varPlanningReprises);
        Task<AjoutPlanningReprisesModel> Update(AjoutPlanningReprisesModel varPlanningReprises);
        Task<AjoutPlanningReprisesModel> Delete(int id);
    }
    public class AjoutProgrammeService : IAjoutProgrammeService
    {
        private readonly ApplicationDbContext _context;

        public AjoutProgrammeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<AjoutPlanningReprisesModel>> Get()
        {
            return await _context.PlanningReprisesModel.ToListAsync();
        }

        public async Task<AjoutPlanningReprisesModel> Get(int id)
        {
            var varPlanningReprises = await _context.PlanningReprisesModel.FindAsync(id);
            return varPlanningReprises;
        }

        public async Task<AjoutPlanningReprisesModel> Add(AjoutPlanningReprisesModel varPlanningReprises)
        {
            _context.PlanningReprisesModel.Add(varPlanningReprises);
            await _context.SaveChangesAsync();
            return varPlanningReprises;
        }

        public async Task<AjoutPlanningReprisesModel> Update(AjoutPlanningReprisesModel varPlanningReprises)
        {
            _context.Entry(varPlanningReprises).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return varPlanningReprises;
        }

        public async Task<AjoutPlanningReprisesModel> Delete(int id)
        {
            var varPlanningReprises = await _context.PlanningReprisesModel.FindAsync(id);
            _context.PlanningReprisesModel.Remove(varPlanningReprises);
            await _context.SaveChangesAsync();
            return varPlanningReprises;
        }
    }
}
