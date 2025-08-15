using System.Collections.Generic;using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform weaponPoint;

    private int _currentHealth;
    private int _currentWeaponNumber = 0;
    private Weapon _currentWeapon;
    
    public event UnityAction<int, int> OnHealthChanged;
    public event UnityAction<int> OnMoneyChanged;
    
    public int Money { get; private set; }
    
    void Start()
    {
        ChangeWeapon(weapons[_currentWeaponNumber]);
        _currentWeapon = weapons[0];
        _currentHealth = health;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsClickedOnButton() && Time.timeScale != 0)
        {
            _currentWeapon.Shoot(shootPoint);    
        }    
    }

    private bool IsClickedOnButton()
    {
        bool result = false;
        
        if (EventSystem.current.IsPointerOverGameObject())
        { 
            GameObject clickedObject = EventSystem.current.currentSelectedGameObject;
            if (clickedObject != null && clickedObject.TryGetComponent(out Button _)) result = true;
        }

        return result;
    }


    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        OnHealthChanged?.Invoke(_currentHealth, health);
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        OnMoneyChanged?.Invoke(Money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        OnMoneyChanged?.Invoke(Money);
        weapons.Add(weapon);
        
        Instantiate(weapon, weaponPoint.position, Quaternion.identity, weaponPoint);
        NextWeapon();
        
    }

    public void NextWeapon()
    {
        _currentWeaponNumber = _currentWeaponNumber == weapons.Count - 1 ? 0 : _currentWeaponNumber + 1;
        ChangeWeapon(weapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        _currentWeaponNumber = _currentWeaponNumber == 0 ? weapons.Count - 1 : _currentWeaponNumber - 1;
        ChangeWeapon(weapons[_currentWeaponNumber]);        
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
        Weapon[] weaponsObjects = weaponPoint.GetComponentsInChildren<Weapon>(true);
        foreach (var weaponObject in weaponsObjects)
        {
            weaponObject.gameObject.SetActive(weaponObject.Label == _currentWeapon.Label);
        }
    }
    
}
