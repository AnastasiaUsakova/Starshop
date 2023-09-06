using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Shop
{
    public class BaseShopElementView : MonoBehaviour
    {
        [SerializeField] private Image elementRenderer;
        [SerializeField] private TextMeshProUGUI price;
        [SerializeField] private TextMeshProUGUI quantity;
        [SerializeField] private Button button;

        private ShopElementModel _model;

        public void Initialize(ShopElementModel model)
        {
            _model = model;
            elementRenderer.sprite = model.Icon;
            price.text = model.Price;
            quantity.text = model.Quantity;
            quantity.gameObject.SetActive(model.QuantityLabelEnabled);
            button.onClick.AddListener(OnClicked);
        }

        private void OnClicked()
        {
            _model.BuyItem();
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnClicked);
        }
    }
}