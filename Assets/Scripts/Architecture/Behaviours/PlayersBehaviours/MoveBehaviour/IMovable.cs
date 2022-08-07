using UnityEngine;

public interface IMovable :  IHaveMoveSpeed
{ 
}

public interface IMoveAndRotate : IMovable, IHaveRotationSmoothTime, IJump
{ 
}

public interface IHaveMoveSpeed
{
    float MoveSpeed { get; }
    float SpeedChangeRate { get; }
}

public interface IHaveRotationSmoothTime
{
    float RotationSmoothTime { get; }
}

public interface IJump
{
    public float JumpHeight { get; }

    public float Gravity { get; }

    public float JumpTimeout { get; }

    public float FallTimeout { get;}

    public float GroundedOffset { get;}

    public float GroundedRadius { get; }

    public LayerMask GroundLayers { get; }
}