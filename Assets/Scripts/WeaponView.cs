using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text label;
    [SerializeField] private TMP_Text price;
    [SerializeField] private Button sellButton;

    private Weapon _weapon;
    
    public event UnityAction<Weapon, WeaponView> OnSellButtonClick;
    
    private void OnEnable()
    {
        sellButton.onClick.AddListener(OnButtonClick);
        sellButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        sellButton.onClick.RemoveListener(OnButtonClick);
        sellButton.onClick.RemoveListener(TryLockItem);
    }

    private void TryLockItem()
    {
        if (_weapon.IsBought)
        {
            sellButton.interactable = false;
        }
    }
    
    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        icon.sprite = weapon.Icon;
        label.text = weapon.Label;
        price.text = weapon.Price.ToString();
    }
    
    private void OnButtonClick()
    {
        OnSellButtonClick?.Invoke(_weapon, this);    
    }
    
}
