using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private Player player;
    [SerializeField] private WeaponView template;
    [SerializeField] private GameObject itemsContainer;

    private List<WeaponView> _weaponViews = new List<WeaponView>();
    
    private void Start()
    {
        foreach (var item in weapons)
        {
            AddItem(item);
        }
        
    }

    private void OnEnable()
    {
        foreach (var item in _weaponViews)
        {
            SetSellButtonAccessibility(item);
        }    
    }

    private void SetSellButtonAccessibility(WeaponView weaponView)
    {
        weaponView.SellButton.interactable = player.Money >= weaponView.Weapon.Price && !weaponView.Weapon.IsBought;
    }

    private void AddItem(Weapon weapon)
    {
        var item = Instantiate(template, itemsContainer.transform);
        item.OnSellButtonClick += OnSellButtonClick;
        item.Render(weapon);
        SetSellButtonAccessibility(item);
        _weaponViews.Add(item);
    }

    private void OnSellButtonClick(Weapon weapon, WeaponView weaponView)
    {
        TrySellWeapon(weapon, weaponView);
    }

    private void TrySellWeapon(Weapon weapon, WeaponView weaponView)
    {
        if (weapon.Price <= player.Money)
        {
            player.BuyWeapon(weapon);
            weapon.Buy();
            weaponView.OnSellButtonClick -= OnSellButtonClick;
        }    
    }
    
}
