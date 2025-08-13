using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int reward;
    
    private Player _target;
    
    public Player Target => _target;
    public int Reward => reward;
    
    public event UnityAction<Enemy> OnDeath;

    public void Init(Player target)
    {
        _target = target;
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            OnDeath?.Invoke(this);
        }
    }
    
}
