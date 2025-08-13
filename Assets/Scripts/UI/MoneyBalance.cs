using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text money;
    [SerializeField] private Player player;

    private void OnEnable()
    {
        money.text = player.Money.ToString();
        player.OnMoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        player.OnMoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int playerMoney)
    {
        money.text = playerMoney.ToString();
    }
    
}
