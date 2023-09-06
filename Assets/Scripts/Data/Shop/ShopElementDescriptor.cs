using Player;
using UnityEngine;

namespace Data.Shop
{
    [CreateAssetMenu(fileName = "ShopElement", menuName = "Data/Shop/Shop Element")]
    public class ShopElementDescriptor : ScriptableObject
    {
        [SerializeField] private ResourceItemType resourceItemType;
        [SerializeField] private int itemQuantity;
        [SerializeField] private int itemPrice;
        [SerializeField] private Sprite itemIcon;
        [SerializeField] private bool equipped;

        public ResourceItemType ResourceItemType => resourceItemType;
        public int ItemQuantity => itemQuantity;
        public int ItemPrice => itemPrice;
        public Sprite ItemIcon => itemIcon;
        public bool Equipped => equipped;
    }
}