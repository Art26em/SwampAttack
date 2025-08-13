using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player player;

    private void OnEnable()
    {
        player.OnHealthChanged += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        player.OnHealthChanged -= OnValueChanged;
    }
    
}
