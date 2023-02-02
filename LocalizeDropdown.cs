using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace UVH.Localization
{
    [RequireComponent(typeof(Dropdown))]
    [AddComponentMenu("Localization/Localize Dropdown")]
    public class LocalizeDropdown : MonoBehaviour
    {

        [Serializable]
        public class LocalizedDropdownOption
        {
            public LocalizedString text;
        }

        public List<LocalizedDropdownOption> options;
        public int selectedOptionIndex = 0;
        private Locale currentLocale = null;
        private Dropdown Dropdown => GetComponent<Dropdown>();


        private void Start()
        {
            getLocale();
            UpdateDropdown(currentLocale);
            LocalizationSettings.SelectedLocaleChanged += UpdateDropdown;
        }


        private void OnEnable() => LocalizationSettings.SelectedLocaleChanged += UpdateDropdown;
        private void OnDisable() => LocalizationSettings.SelectedLocaleChanged -= UpdateDropdown;
        void OnDestroy() => LocalizationSettings.SelectedLocaleChanged -= UpdateDropdown;



        private void getLocale()
        {
            var locale = LocalizationSettings.SelectedLocale;
            if (currentLocale != null && locale != currentLocale)
            {
                currentLocale = locale;
            }
        }


        private void UpdateDropdown(Locale locale)
        {
            selectedOptionIndex = Dropdown.value;
            Dropdown.ClearOptions();

            for (int i = 0; i < options.Count; i++)
            {
                //sprite functionality isn't ready yet.
                Sprite localizedSprite = null;

                String localizedText = options[i].text.GetLocalizedString();
                Dropdown.options.Add(new Dropdown.OptionData(localizedText, localizedSprite));
            }

            Dropdown.value = selectedOptionIndex;
            Dropdown.RefreshShownValue();
        }

    }
}