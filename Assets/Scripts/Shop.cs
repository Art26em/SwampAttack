using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private Player player;
    [SerializeField] private WeaponView template;
    [SerializeField] private GameObject itemsContainer;

    private void Start()
    {
        foreach (var item in weapons)
        {
            AddItem(item);
        }
    }

    private void AddItem(Weapon weapon)
    {
        var item = Instantiate(template, itemsContainer.transform);
        item.OnSellButtonClick += OnSellButtonClick;
        item.Render(weapon);
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
