using Data.Shop;
using GameData;
using Player;
using Utils;

namespace Logic
{
    public class ShopManager : Singleton<ShopManager>
    {
        public bool TryPurchaseItem(ShopElementDescriptor descriptor)
        {
            var gameData = GameDataPersist.Instance.GameData;
            if (gameData.PlayerCoins < descriptor.ItemPrice)
                return false;

            if (!descriptor.Equipped && descriptor.ResourceItemType == ResourceItemType.Coins)
            {
                gameData.PlayerCoins += descriptor.ItemQuantity;
                DecreasePlayerCoins(descriptor.ItemPrice);
                return true;
            }

            //todo: add swapping current element when there'll be more than one of each
            
            if (descriptor.Equipped)
            {
                var itemOnPlayer = gameData.EquippedItemsList.Find(i => i.Resource
                                                                        == descriptor.ResourceItemType);
                if (itemOnPlayer == null)
                {
                    var equippedItem = new EquippedItem
                    {
                        Equipped = true,
                        Resource = descriptor.ResourceItemType
                    };
                    gameData.EquippedItemsList.Add(equippedItem);
                    DecreasePlayerCoins(descriptor.ItemPrice);
                    return true;
                }

                return false;
            }
            return false;
        }

        private void DecreasePlayerCoins(int price)
        {
            GameDataPersist.Instance.GameData.PlayerCoins -= price;
        }
    }
}