using System;
using Common;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace EditMode.UI.Popups
{
    public class CityPicker : PopupPanel
    {
        [SerializeField] private CityContainer cityContainer;
        [SerializeField] private CityPickerItem itemPrefab;
        [SerializeField] private Transform scrollViewTransform;
        [SerializeField] private ToggleGroup toggleGroup;

        private void Awake()
        {
            Assert.IsNotNull(cityContainer);
            Assert.IsNotNull(itemPrefab);

            foreach (var city in cityContainer.Cities)
            {
                var newItem = Instantiate(itemPrefab, scrollViewTransform);
                newItem.Setup(toggleGroup, city.name);
            }
        }

        public void SelectCity()
        {
            string cityName = null;
            foreach (var toggle in toggleGroup.ActiveToggles())
            {
                var item = toggle.GetComponentInParent<CityPickerItem>();
                cityName = item.CityName;
            }

            if (string.IsNullOrEmpty(cityName))
            {
                return;
            }

            WorldManager.Instance.City = cityContainer.GetCity(cityName);
            Close();
        }
    }
}
