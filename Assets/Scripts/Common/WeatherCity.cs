using System;
using UnityEngine;

namespace Common
{
    [Serializable]
    public class WeatherCity
    {
        [Serializable]
        public class Weather
        {
            [Serializable]
            public class Summary
            {
                public string title;
                public string description;
            }

            public Summary summary;
            public long timestamp;
        }
        
        public string name;
        public Weather weather;
    }

    [Serializable]
    public class GetCityByNameWrapper
    {
        [Serializable]
        public class GetCityByNameData
        {
            public WeatherCity getCityByName;
        }

        public GetCityByNameData data;
    }
}
