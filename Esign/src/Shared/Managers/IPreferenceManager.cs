using Esign.Shared.Settings;
using System.Threading.Tasks;
using Esign.Shared.Wrapper;

namespace Esign.Shared.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();

        Task<IResult> ChangeLanguageAsync(string languageCode);
    }
}