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
        public readonly int Quantity;
        public readonly bool QuantityLabelEnabled;
        public readonly Sprite Icon;
        
        private readonly bool _equipped;
        private readonly IShopCustomer _shopCustomer;
        private readonly ShopElementDescriptor _descriptor;
        
        public ShopElementModel(ShopElementDescriptor descriptor, IShopCustomer shopCustomer)
        {
            _descriptor = descriptor;
            _shopCustomer = shopCustomer;
            ItemType = descriptor.ResourceItemType;
            Price = descriptor.ItemPrice.ToString();
            var itemQuantity = descriptor.ItemQuantity;
            Quantity = itemQuantity;
            Icon = descriptor.ItemIcon;
            QuantityLabelEnabled = itemQuantity > 1;
            _equipped = descriptor.Equipped;
        }

        public void BuyItem()
        {
            if (ShopManager.Instance.TryPurchaseItem(_descriptor) && _equipped)
                _shopCustomer.ItemBoughtCallback(ItemType, Icon);
        }
    }
}