using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    private Animator _animator;

    private const string CelebrationAnimationName = EnemyAnimations.Celebration;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(CelebrationAnimationName);    
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
