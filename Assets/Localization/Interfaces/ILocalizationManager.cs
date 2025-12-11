using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Localization.Interfaces
{
    public interface ILocalizationManager
    {
        public event UnityAction OnLanguageChanged;
        public void ChangeLanguage(SystemLanguage language);
        public string Get(string key, string fallback = "MISSING");
        public SystemLanguage CurrentLanguage { get; }
    }
}
