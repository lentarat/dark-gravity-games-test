using DarkGravityGames.Task2;
using System;
using UnityEngine;

namespace DarkGravityGames.Task2
{
    [Serializable]
    public struct InventoryItemMapping
    {
        [SerializeField] private InventoryItemType _inventoryItemType;
        public InventoryItemType InventoryItemType => _inventoryItemType;
        [SerializeField] private Sprite _sprite;
        public Sprite Sprite => _sprite;
    }
}