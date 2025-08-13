using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float speed;

    private void Update()
    {
        if (!Target) return;
        transform.position = Vector2.MoveTowards(
            transform.position, 
            Target.transform.position, 
            speed * Time.deltaTime);
    }
}
