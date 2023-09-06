using System;
using UI.Shop;
using UnityEngine;

namespace Logic
{
    public class ShopWindowTrigger : MonoBehaviour
    {
        [SerializeField] private ShopWindow shopWindow;
        private void OnTriggerEnter2D(Collider2D enteredCollider)
        {
            var shopCustomer = enteredCollider.GetComponent<IShopCustomer>();
            if (shopCustomer != null)
            {
                shopWindow.Initialize(shopCustomer);
            }
        }
        
        private void OnTriggerExit2D(Collider2D enteredCollider)
        {
            var shopCustomer = enteredCollider.GetComponent<IShopCustomer>();
            if (shopCustomer != null)
            {
                shopWindow.CloseShop();
            }
        }
    }
}