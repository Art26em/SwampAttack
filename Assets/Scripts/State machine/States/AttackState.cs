using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int damage;
    [SerializeField] private float delay;
    
    private float _lastAttackTime;
    private Animator _animator;

    private const string AttackAnimationName = EnemyAnimations.Attack;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = delay;
        }
        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _animator.Play(AttackAnimationName);
        target.TakeDamage(damage);
    }
    
}
