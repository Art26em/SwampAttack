using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> waves;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Player player;
    
    public event UnityAction AllEnemiesSpawned;
    public event UnityAction<int, int> OnEnemiesCountChanged;
    
    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;

    private void Start()
    {
        SetWave(_currentWaveNumber);    
    }

    private void Update()
    {
        if (_currentWave == null) return;

        _timeAfterLastSpawn += Time.deltaTime;
        
        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
            OnEnemiesCountChanged?.Invoke(_spawned, _currentWave.Count);
        }

        if (_currentWave.Count <= _spawned)
        {
            _currentWave = null;
            if (waves.Count > _currentWaveNumber + 1)
            {
                AllEnemiesSpawned?.Invoke();
            }    
            
        }
        
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template,  spawnPoint.position, spawnPoint.rotation, spawnPoint).GetComponent<Enemy>();
        enemy.Init(player);
        enemy.OnDeath += OnEnemyDying;
    }
    
    private void SetWave(int index)
    {
        _currentWave = waves[index];
        OnEnemiesCountChanged?.Invoke(0, 1);
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.OnDeath -= OnEnemyDying;
        player.AddMoney(enemy.Reward);
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
    }
    
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
