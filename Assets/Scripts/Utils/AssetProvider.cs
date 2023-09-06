using Data.Shop;
using Player;
using UnityEngine;

namespace Utils
{
    public static class AssetProvider
    {
        private const string SHOP_ITEMS_PATH = "Data/ShopElements";
        
        public static ShopElementDescriptor GetShopElementDescriptor(ResourceItemType resourceItemType)
        {
            var path = $"{SHOP_ITEMS_PATH}/{resourceItemType}";
            var res = Resources.Load<ShopElementDescriptor>(path);
            return Object.Instantiate(res);
        }
    }
}