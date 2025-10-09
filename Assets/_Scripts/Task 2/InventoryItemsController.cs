using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace DarkGravityGames.Task2
{
    public class InventoryItemsController : MonoBehaviour
    {
        [SerializeField] private Button _addIconButton;
        [SerializeField] private Button _removeIconButton;
        [SerializeField] private Transform _itemsParent;
        [SerializeField] private InventoryItem _inventoryItemPrefab;
        [SerializeField] private InventoryItemMapping[] _itemSpriteMappings;
        [SerializeField] private int _maxItemsCount;

        private List<InventoryItem> _inventoryItemsList = new();

        private void Awake()
        {
            SubscribeToButtons();
        }

        private void SubscribeToButtons()
        { 
            _addIconButton.onClick.AddListener(() => AddRandomIcon());
            _removeIconButton.onClick.AddListener(() => RemoveLastIcon());
        }

        private void AddRandomIcon()
        {
            if (_itemSpriteMappings.Length == 0)
            {
                throw new Exception("No items mapped");
            }

            if (_inventoryItemsList.Count >= _maxItemsCount)
            {
                return;
            }

            int randomIconIndex = UnityEngine.Random.Range(0, _itemSpriteMappings.Length);
            InventoryItem newInventoryItem = Instantiate(_inventoryItemPrefab, _itemsParent);
            Sprite itemSprite = _itemSpriteMappings[randomIconIndex].Sprite;
            string itemName = _itemSpriteMappings[randomIconIndex].InventoryItemType.ToString();
            newInventoryItem.Init(itemSprite, itemName);
            newInventoryItem.name = itemName + newInventoryItem.name;

            _inventoryItemsList.Add(newInventoryItem);
        }

        private void RemoveLastIcon() 
        {
            if (_inventoryItemsList.Count == 0)
            {
                return;
            }

            int itemIndex = _inventoryItemsList.Count - 1;
            Destroy(_inventoryItemsList[itemIndex].gameObject);
            _inventoryItemsList.RemoveAt(itemIndex);
        }
    }
}
