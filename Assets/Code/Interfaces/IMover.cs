using UnityEngine;

namespace GameProgramming1
{
    public interface IMover
    {
        // Position of this object in world space
        Vector3 Position { get; set; }


        // Rotation of this object in world space
        Quaternion Rotation { get; set; }

        // The speed of this mover
        float Speed { get; }


        // Move toward targetPosition
        void MoveTowardPosition(Vector3 targetPosition);

        // Move to direction 'direction'
        void MoveToDirection(Vector3 direction);

        void RotateTowardPosition(Vector3 targetPosition);
    }
}