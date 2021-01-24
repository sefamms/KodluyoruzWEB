using KodluyoruzWEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KodluyoruzWEB.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}