using System;
using System.Collections.Generic;
using UnityEngine;

namespace EditMode
{
    [CreateAssetMenu(fileName = "PrefabContainer", menuName = "PrefabContainer")]
    public class PrefabContainer : ScriptableObject
    {
        [Serializable]
        public class PrefabInfo
        {
            public string name;
            public GameObject prefab;
            public Sprite preview;
        }
        
        [SerializeField] private PrefabInfo[] characters;
        public IEnumerable<PrefabInfo> Characters => characters;

        [SerializeField] private PrefabInfo[] doodads;
        public IEnumerable<PrefabInfo> Doodads => doodads;
    }
}
