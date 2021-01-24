using KodluyoruzWEB.Data;
using KodluyoruzWEB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KodluyoruzWEB.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly BookStoreContext _context = null;

        public LanguageRepository(BookStoreContext context)
        {
            _context = context;
        }


        public async Task<List<LanguageModel>> GetLanguages()
        {
            var languages = await _context.Languages.Select(x => new LanguageModel()
            {
                id = x.id,
                name = x.name,
                description = x.description

            }).ToListAsync();
            return languages;
        }


    }
}
