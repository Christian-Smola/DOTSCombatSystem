using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float MovementSpeed;
    public float3 MovementDirection;

    private class Baker : Baker<MoveCube>
    {
        public override void Bake(MoveCube authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new CubeSystems._Move { movementSpeed = authoring.MovementSpeed, movementDirection = authoring.MovementDirection });
        }
    }
}