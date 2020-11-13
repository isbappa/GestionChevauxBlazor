 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionChevauxBlazor.Data;
using GestionChevauxBlazor.Models;
using Microsoft.EntityFrameworkCore;


namespace GestionChevauxBlazor.Services
{
    public interface IAjoutChevauxService
    {
        Task<List<AjoutChevauxModel>> Get();
        Task<AjoutChevauxModel> Get(int id);
        Task<AjoutChevauxModel> Add(AjoutChevauxModel varGestionChevaux);
        Task<AjoutChevauxModel> Update(AjoutChevauxModel varGestionChevaux);
        Task<AjoutChevauxModel> Delete(int id);
    }
    public class AjoutChevauxService : IAjoutChevauxService
    {
        private readonly ApplicationDbContext _context;

        public AjoutChevauxService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<AjoutChevauxModel>> Get()
        {
            return await _context.GestionChevauxModel.ToListAsync();
        }

        public async Task<AjoutChevauxModel> Get(int id)
        {
            var varGestionChevaux = await _context.GestionChevauxModel.FindAsync(id);
            return varGestionChevaux;
        }

        public async Task<AjoutChevauxModel> Add(AjoutChevauxModel varGestionChevaux)
        {
            _context.GestionChevauxModel.Add(varGestionChevaux);
            await _context.SaveChangesAsync();
            return varGestionChevaux;
        }
        
        public async Task<AjoutChevauxModel> Update(AjoutChevauxModel varGestionChevaux)
        {
            _context.Entry(varGestionChevaux).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return varGestionChevaux;
        }

        public async Task<AjoutChevauxModel> Delete(int id)
        {
            var varGestionChevaux = await _context.GestionChevauxModel.FindAsync(id);
            _context.GestionChevauxModel.Remove(varGestionChevaux);
            await _context.SaveChangesAsync();
            return varGestionChevaux;
        }
    }
}
