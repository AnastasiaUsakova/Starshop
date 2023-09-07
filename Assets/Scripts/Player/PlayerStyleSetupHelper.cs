using System;
using System.Collections.Generic;
using System.Linq;
using GameData;
using UnityEngine;
using Utils;

namespace Player
{
    [Serializable]
    public class ElementRenderer
    {
        [SerializeField] public ResourceItemType resourceItem;
        [SerializeField] public SpriteRenderer itemRenderer;
    }

    public class PlayerStyleSetupHelper : MonoBehaviour
    {
        [SerializeField] private ElementRenderer[] equipmentRenderers;

        public void Initialize(List<EquippedItem> playerPurchasedItems)
        {
            if (playerPurchasedItems == null || playerPurchasedItems.Count == 0)
            {
                return;
            }

            foreach (var item in playerPurchasedItems)
            {
                if (!item.Equipped)
                    continue;
                
                var itemDescriptor = AssetProvider.GetShopElementDescriptor(item.Resource);
                EquipElement(item.Resource, itemDescriptor.ItemIcon);
            }
        }

        public void EquipElement(ResourceItemType item, Sprite icon)
        {
            var itemRenderer = equipmentRenderers.FirstOrDefault(i => i.resourceItem == item);
            if (itemRenderer == null)
                return;
            
            itemRenderer.itemRenderer.sprite = icon;
        }

    }
}