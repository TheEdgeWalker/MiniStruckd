using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EditMode.UI.Popups
{
    public class CityPickerItem : MonoBehaviour
    {
        [SerializeField] private Toggle toggle;
        [SerializeField] private TMP_Text cityName;

        private string _cityName;
        public string CityName
        {
            get => _cityName;
            private set
            {
                _cityName = value;
                cityName.text = value;
            }
        }

        public void Setup(ToggleGroup toggleGroup, string city)
        {
            toggle.group = toggleGroup;
            CityName = city;
        }
    }
}
