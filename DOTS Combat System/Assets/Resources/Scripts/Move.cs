using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float MovementSpeed;
    public float3 MovementDirection;

    private class Baker : Baker<Move>
    {
        public override void Bake(Move authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Systems._Move { movementSpeed = authoring.MovementSpeed });
        }
    }
}