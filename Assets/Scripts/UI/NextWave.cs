using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private Button  nextWaveButton;

    private void OnEnable()
    {
        spawner.AllEnemiesSpawned += AllEnemiesSpawned;
        nextWaveButton.onClick.AddListener(OnNextWaveButtonClick);
    }

    private void OnDisable()
    {
        spawner.AllEnemiesSpawned -= AllEnemiesSpawned;
        nextWaveButton.onClick.RemoveListener(OnNextWaveButtonClick);
    }

    private void AllEnemiesSpawned()
    {
        nextWaveButton.gameObject.SetActive(true);
    }

    public void OnNextWaveButtonClick()
    {
        spawner.NextWave();
        nextWaveButton.gameObject.SetActive(false);
    }
    
}
