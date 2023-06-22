using System.Linq;
using Esign.Shared.Constants.Localization;
using Esign.Shared.Settings;

namespace Esign.Server.Settings
{
    public record ServerPreference : IPreference
    {
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";

        //TODO - add server preferences
    }
}