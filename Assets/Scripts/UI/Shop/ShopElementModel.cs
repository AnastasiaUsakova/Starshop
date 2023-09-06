using Data.Shop;
using Logic;
using Player;
using UnityEngine;

namespace UI.Shop
{
    public class ShopElementModel
    {
        public readonly ResourceItemType ItemType;
        public readonly string Price;
        public readonly string Quantity;
        public readonly bool QuantityLabelEnabled;
        public readonly bool Equipped;
        public readonly Sprite Icon;

        private IShopCustomer _shopCustomer;
        
        public ShopElementModel(ShopElementDescriptor descriptor, IShopCustomer shopCustomer)
        {
            _shopCustomer = shopCustomer;
            ItemType = descriptor.ResourceItemType;
            Price = descriptor.ItemPrice.ToString();
            var itemQuantity = descriptor.ItemQuantity;
            Quantity = $"x{itemQuantity}";
            Icon = descriptor.ItemIcon;
            QuantityLabelEnabled = itemQuantity > 1;
            Equipped = descriptor.Equipped;
        }

        public void BuyItem()
        {
            if (Equipped)
            {
                //equip player
            }
            _shopCustomer.BuyItem(ItemType);
            //save to resources using item type from model
        }
    }
}