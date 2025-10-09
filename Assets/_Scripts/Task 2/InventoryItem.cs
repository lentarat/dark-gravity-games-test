using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DarkGravityGames.Task2
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _iconNameText;

        public void Init(Sprite iconSprite, string iconName)
        {
            _iconImage.sprite = iconSprite;
            _iconNameText.text = iconName;
        }
    }
}
