using System;
using UnityEngine;

namespace EditMode.UI.Popups
{
    public abstract class PopupPanel : MonoBehaviour
    {
        public void Close()
        {
            PopupManager.Close();
        }
    }
}
