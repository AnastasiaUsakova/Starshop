using Player;
using UnityEngine;

namespace Logic
{
    public interface IShopCustomer
    {
        void ItemBoughtCallback(ResourceItemType itemType, Sprite icon);
    }
}