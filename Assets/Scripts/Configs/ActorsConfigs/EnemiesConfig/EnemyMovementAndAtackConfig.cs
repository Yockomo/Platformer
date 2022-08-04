using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemiesConfigs/EnemyChaiseMoveConfig", order = 1)]
public class EnemyMovementAndAtackConfig : ScriptableObject
{
    [SerializeField] private float _stoppingDistance = 1;
    
    [SerializeField] private float _reactDistance = 3;
    
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 3;

    public float StoppingDistance => _stoppingDistance;
    public float ReactDistance => _reactDistance;
    public float MoveSpeed => _moveSpeed;
}
