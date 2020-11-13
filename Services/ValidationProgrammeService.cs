using GestionChevauxBlazor.Data;
using GestionChevauxBlazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionChevauxBlazor.Services
{
    public interface IValidationProgrammeService
    {
        Task<List<ValidationPlanningRepriseModel>> Get();
        Task<ValidationPlanningRepriseModel> Get(int id);
        Task<ValidationPlanningRepriseModel> Add(ValidationPlanningRepriseModel varPlanningReprises);
        Task<ValidationPlanningRepriseModel> Update(ValidationPlanningRepriseModel varPlanningReprises);
        Task<ValidationPlanningRepriseModel> Delete(int id);
    }
    public class ValidationProgrammeService : IValidationProgrammeService
    {
        private readonly ApplicationDbContext _context;

        public ValidationProgrammeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ValidationPlanningRepriseModel>> Get()
        {
            return await _context.ValidationPlanningRepriseModel.ToListAsync();
        }

        public async Task<ValidationPlanningRepriseModel> Get(int id)
        {
            var varPlanningReprises = await _context.ValidationPlanningRepriseModel.FindAsync(id);
            return varPlanningReprises;
        }

        public async Task<ValidationPlanningRepriseModel> Add(ValidationPlanningRepriseModel varPlanningReprises)
        {
            _context.ValidationPlanningRepriseModel.Add(varPlanningReprises);
            await _context.SaveChangesAsync();
            return varPlanningReprises;
        }

        public async Task<ValidationPlanningRepriseModel> Update(ValidationPlanningRepriseModel varPlanningReprises)
        {
            _context.Entry(varPlanningReprises).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return varPlanningReprises;
        }

        public async Task<ValidationPlanningRepriseModel> Delete(int id)
        {
            var varPlanningReprises = await _context.ValidationPlanningRepriseModel.FindAsync(id);
            _context.ValidationPlanningRepriseModel.Remove(varPlanningReprises);
            await _context.SaveChangesAsync();
            return varPlanningReprises;
        }
    }
}
