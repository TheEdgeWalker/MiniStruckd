using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common
{
    [CreateAssetMenu(fileName = "CityContainer", menuName = "CityContainer")]
    public class CityContainer : ScriptableObject
    {
        [Serializable]
        public class City
        {
            public string name;
            public int offset;
        }

        [SerializeField] private City[] cities;
        public IEnumerable<City> Cities => cities;

        public City GetCity(string cityName)
        {
            return cities.FirstOrDefault(city => city.name == cityName);
        }
    }
}
