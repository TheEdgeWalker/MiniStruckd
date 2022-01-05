using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace EditMode.UI.Popups
{
    public class ObjectPickerItem : MonoBehaviour, ISelectable, IPointerClickHandler
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private Image previewImage;
        [SerializeField] private Image selectedFrame;

        public GameObject Prefab { get; private set; }

        private ObjectPicker _objectPicker;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Assert.IsNotNull(_objectPicker);
            _objectPicker.Select(this);
        }

        public void Setup(ObjectPicker objectPicker, string nameString, Sprite previewSprite, GameObject prefab)
        {
            _objectPicker = objectPicker;
            nameText.text = nameString;
            previewImage.sprite = previewSprite;
            Prefab = prefab;
        }

        public void Select(bool isSelected)
        {
            selectedFrame.gameObject.SetActive(isSelected);
        }
    }
}
