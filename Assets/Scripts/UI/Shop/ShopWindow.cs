using System;
using System.Collections.Generic;
using Logic;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Shop
{
    public class ShopWindow : MonoBehaviour
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private TextMeshProUGUI playerCoins;
        [SerializeField] private GridLayoutGroup shopElementsGrid;
        [SerializeField] private BaseShopElementView baseShopElementView;
        [SerializeField] private ResourceItemType[] displayedShopTypes;

        private List<BaseShopElementView> _elementViews = new List<BaseShopElementView>();
        private IShopCustomer _shopCustomer;
        private bool _initialized;

        public void Initialize(IShopCustomer shopCustomer)
        {
            if (_initialized)
            {
                Show();
                return;
            }
            
            _shopCustomer = shopCustomer;
            var coins = 100;// init from save&load
            playerCoins.text = coins < 1 ? $"<color=red>{coins}</color>" : $"<color=yellow>{coins}</color>";
            foreach (var type in displayedShopTypes)
            {
                var itemDescriptor = AssetProvider.GetShopElementDescriptor(type);
                var view = Instantiate(baseShopElementView, shopElementsGrid.transform);
                view.Initialize(new ShopElementModel(itemDescriptor, shopCustomer));
                _elementViews.Add(view);
            }
            closeButton.onClick.AddListener(CloseShop);
            _initialized = true;
            Show();
        }

        private void Show()
            => gameObject.SetActive(true);

        public void CloseShop()
            => gameObject.SetActive(false);

        private void ClearElements()
        {
            foreach (var shopElement in _elementViews)
            {
                Destroy(shopElement);
            }
            _elementViews.Clear();
        }

        private void OnDestroy()
        {
            ClearElements();
            closeButton.onClick.RemoveListener(CloseShop);
        }
    }
}