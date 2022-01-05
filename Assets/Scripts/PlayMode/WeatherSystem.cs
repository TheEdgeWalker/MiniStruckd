using System;
using Common;
using UnityEngine;

namespace PlayMode
{
    public class WeatherSystem : MonoBehaviour
    {
        [Serializable]
        public class Weather
        {
            public string name;
            public GameObject instance;
        }

        [SerializeField] private Weather[] weathers;

        public void SetWeather(string weatherName)
        {
            Debug.Log($"Setting weather to {weatherName}");
            foreach (var weather in weathers)
            {
                var isMatch = weather.name == weatherName;
                weather.instance.SetActive(isMatch);
                var parent = isMatch ? WorldManager.Instance.Player.transform : transform;
                weather.instance.transform.SetParent(parent, false);
            }
        }
    }
}
