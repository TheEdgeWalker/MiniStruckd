#if UNITY_EDITOR

using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEditor;
using UnityEngine;

namespace EditMode
{
    [CustomEditor(typeof(PrefabContainer))]
    public class PrefabContainerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Generate previews"))
            {
                var container = (PrefabContainer)target;
                CreateAssetPreviews(container.Characters);
                CreateAssetPreviews(container.Doodads);
                AssetDatabase.Refresh();
            }
        }

        private void CreateAssetPreviews(IEnumerable<PrefabContainer.PrefabInfo> infos)
        {
            foreach (var info in infos)
            {
                Texture2D preview = null;
                while (preview == null)
                {
                    // GetAssetPreview is actually async... sometimes returns null if it is not ready
                    preview = AssetPreview.GetAssetPreview(info.prefab);
                    Thread.Sleep(100);
                }
                var png = preview.EncodeToPNG();
                File.WriteAllBytes($"{Application.dataPath}/Sprites/Previews/{info.name}.png", png);
            }
        }
    }
}

#endif