using System;
using System.Collections;
using System.ComponentModel;
using System.Text;
using Common;
using GraphQlClient.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace PlayMode
{
    public class PlayModeManager : MonoBehaviour
    {
        private const long SecondsPerDay = 24 * 60 * 60;
        
        [SerializeField] private GraphApi weatherApi;
        [SerializeField] private float fetchWeatherInterval;
        [SerializeField] private Light sun;
        [SerializeField] private Light moon;
        [SerializeField] private TMP_Text cityText;
        [SerializeField] private TMP_Text clockText;
        [SerializeField] private WeatherSystem weatherSystem;
        [SerializeField] private bool sunMoonRotation;

        private CityContainer.City _city;
        private readonly StringBuilder _timeSb = new StringBuilder("12:34:56");
        
        private void Awake()
        {
            _city = WorldManager.Instance.City;
            cityText.text = _city.name;

            StartCoroutine(GetWeatherCoroutine(fetchWeatherInterval));
        }

        private void Update()
        {
            if (!sunMoonRotation)
                return;
            
            // going to use system time because timestamp from the weather API is not reliable
            var now = DateTime.UtcNow.AddHours(_city.offset);

            // hours
            _timeSb[0] = IntToChar(now.Hour / 10);
            _timeSb[1] = IntToChar(now.Hour % 10);
            // minutes
            _timeSb[3] = IntToChar(now.Minute / 10);
            _timeSb[4] = IntToChar(now.Minute % 10);
            // seconds
            _timeSb[6] = IntToChar(now.Second / 10);
            _timeSb[7] = IntToChar(now.Second % 10);

            clockText.text = _timeSb.ToString();

            long todaySeconds = (now.Hour * 60 * 60) + (now.Minute * 60) + now.Second;
            var angleFactor = (float)todaySeconds / SecondsPerDay;

            sun.transform.rotation = Quaternion.Euler(angleFactor * 360f - 90f, 0f, 0f);
            moon.transform.rotation = Quaternion.Euler(angleFactor * 360f - 270f, 0f, 0f);
        }

        private char IntToChar(int num)
        {
            return (char)(num + 48);
        }

        private IEnumerator GetWeatherCoroutine(float interval)
        {
            while (true)
            {
                GetWeather();
                yield return new WaitForSeconds(interval);
            }
        }
        
        private async void GetWeather()
        {
            var query = weatherApi.GetQueryByName("GetCityByName", GraphApi.Query.Type.Query);
            query.SetArgs(new { name = _city.name });
            var request = await weatherApi.Post(query);
            var wrapper = JsonUtility.FromJson<GetCityByNameWrapper>(request.downloadHandler.text);
            
            weatherSystem.SetWeather(wrapper.data.getCityByName.weather.summary.title);
        }
    }
}
