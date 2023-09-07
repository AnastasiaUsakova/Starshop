using System;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace GameData
{
    [Serializable]
    public class GameData
    {
        public Action<int> PlayerCoinsChanged;
        private int _playerCoins = 100;
        public int PlayerCoins
        {
            get => _playerCoins;
            set
            {
                _playerCoins = value;
                PlayerCoinsChanged?.Invoke(_playerCoins);
            }
        }
        public Vector2 PlayerPosition;
        public List<EquippedItem> EquippedItemsList = new List<EquippedItem>();
    }

    [Serializable]
    public class EquippedItem
    {
        public ResourceItemType Resource;
        public bool Equipped;
    }
}