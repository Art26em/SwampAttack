using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string label;
    [SerializeField] private int price;
    [SerializeField] private Sprite icon;
    [SerializeField] private bool isBought = false;
    
    [SerializeField] protected Bullet bullet;
    
    public string Label => label;
    public int Price => price;
    public Sprite Icon => icon;
    public bool IsBought => isBought;
    
    public abstract void Shoot(Transform shootPoint);

    public void Buy()
    {
        isBought = true;
    }
}   
    
