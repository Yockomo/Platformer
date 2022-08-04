﻿using UnityEngine;

[CreateAssetMenu(fileName = "PlayersMovableStats", menuName = "ScriptableObjects/PlayersConfigs/PlayersMoveConfig", order = 2)]
public class PlayersMovableConfig : ScriptableObject, IMoveAndRotate
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float speedChangeRate = 3;
    
    [Header("Rotation settings")]
    [SerializeField] private float rotationSmoothTime = 3;
    
    [Header("Jump and Gravity settings")]
    [SerializeField] private float jumpHeight = 1.2f;
    [SerializeField] private float gravity = -15;
    [SerializeField] private float jumpTimeout = 0.3f;
    [SerializeField] private float fallTimeout = 0.15f;
    [SerializeField] private float groundedOffset = 0.14f;
    [SerializeField] private float groundedRadius = 0.28f;
    [SerializeField] private LayerMask groundLayers;

    public float MoveSpeed => moveSpeed;

    public void SetMoveSpeed(float value)
    {
        if (value >= 0)
        {
            moveSpeed = value;   
        }
    }
    
    public float SpeedChangeRate => speedChangeRate;

    public float RotationSmoothTime => rotationSmoothTime;

    public float JumpHeight => jumpHeight;

    public float Gravity => gravity;

    public float JumpTimeout => jumpTimeout;

    public float FallTimeout => fallTimeout;

    public float GroundedOffset => groundedOffset;

    public float GroundedRadius => groundedRadius;

    public LayerMask GroundLayers => groundLayers;
}