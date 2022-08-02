﻿using UnityEngine;

public class PlayerAnimatorManager : AnimatorManager
{
    private readonly int _atack = Animator.StringToHash("Atack");

    private readonly int _speed = Animator.StringToHash("Speed");
    private readonly int _dash = Animator.StringToHash("Dash");
    private readonly int _grounded = Animator.StringToHash("Grounded");
    private readonly int _dead = Animator.StringToHash("IsDead");

    private readonly int _animIDSpeed = Animator.StringToHash("Speed");
    private readonly int _animIDGrounded = Animator.StringToHash("Grounded");
    private readonly int _animIDJump = Animator.StringToHash("Jump");
    private readonly int _doubleJump = Animator.StringToHash("DoubleJump");

    public PlayerAnimatorManager(Animator animator) : base(animator)
    {
    }
    
    public void SetSpeedParameter(float value)
    {
        _animator.SetFloat(_animIDSpeed, value);
    }

    public void SetGrounded(bool value)
    {
        _animator.SetBool(_animIDGrounded, value);
    }

    public bool IsGrounded()
    {
        return _animator.GetBool(_grounded);
    }
    
    public void SetJump(bool value)
    {
        _animator.SetBool(_animIDJump, value);
    }

    public void TriggerDoubleJump()
    {
        _animator.SetTrigger(_doubleJump);
    }

    public void SetAtack()
    {
        _animator.SetTrigger(_atack);
    }

    public void SetDeadAnimation(bool value)
    {
        _animator.SetBool(_dead, value);
    }

    public float GetSpeed()
    {
        return _animator.GetFloat(_speed);
    }
}
