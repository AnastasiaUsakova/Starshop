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
        public ResourceItemType resourceItem;
        public SpriteRenderer itemRenderer;
        public Animator itemAnimator;
        public string propertyName = "isMoving";
    }

    public class PlayerStyleSetupHelper : MonoBehaviour
    {
        [SerializeField] private ElementRenderer[] equipmentRenderers;

        private List<ElementRenderer> _equippedItems = new List<ElementRenderer>();

        public void Initialize(List<EquippedItem> playerPurchasedItems)
        {
            if (playerPurchasedItems == null || playerPurchasedItems.Count == 0)
            {
                StopAnimations();
                return;
            }

            foreach (var item in playerPurchasedItems)
            {
                if (!item.Equipped)
                    continue;
                
                var itemDescriptor = AssetProvider.GetShopElementDescriptor(item.Resource);
                TryEquipElement(item.Resource, itemDescriptor.ItemIcon);
            }
        }

        public void TryEquipElement(ResourceItemType item, Sprite icon)
        {
            var itemRenderer = equipmentRenderers.FirstOrDefault(i => i.resourceItem == item);
            if (itemRenderer == null)
                return;
            
            itemRenderer.itemRenderer.sprite = icon;
            
            //temporary decision. Potentially store sprite with animation in prefab and store reference to it in SO 
            if (_equippedItems.Find(i => i.resourceItem == item) == null)
                _equippedItems.Add(itemRenderer);
        }

        public void SwitchAnimationFlag(bool moving)
        {
            if (_equippedItems == null || _equippedItems.Count == 0)
            {
                StopAnimations();
                return;
            }
            foreach (var item in _equippedItems)
            {
                if(!item.itemAnimator.enabled)
                    item.itemAnimator.enabled = true;
                
                //todo: find out why change is poorly visible 
                item.itemAnimator.SetBool(Animator.StringToHash(item.propertyName), moving);
            }
        }

        private void StopAnimations()
        {
            foreach (var element in equipmentRenderers)
            {
                element.itemAnimator.enabled = false;
                element.itemRenderer.sprite = null;
            }
        }
    }
}