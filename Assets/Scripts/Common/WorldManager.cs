using System;
using GraphQlClient.Core;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;

namespace Common
{
    public class WorldManager : MonoBehaviour
    {
        public static WorldManager Instance { get; private set; }

        [SerializeField] private GraphApi weatherApi;
        
        public GameObject Player { get; set; }
        public CityContainer.City City { get; set; }

        private void Awake()
        {
            Assert.IsNull(Instance);
            Instance = this;
            
            DontDestroyOnLoad(this);

            Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }
}
