using UnityEngine;

public class Shotgun : Weapon
{
    
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(bullet, shootPoint.position, Quaternion.identity);
    }
}
