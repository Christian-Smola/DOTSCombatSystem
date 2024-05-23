using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace MoveForward
{
    public struct _MoveForward : IComponentData
    {
        public float movementSpeed;
    }

    public partial struct MovementSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            foreach ((RefRW<LocalTransform> transform, RefRO<_MoveForward> move) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<_MoveForward>>())
                transform.ValueRW = transform.ValueRW.RotateY(move.ValueRO.movementSpeed * SystemAPI.Time.DeltaTime);
        }
    }

    public class MoveForward : MonoBehaviour
    {
        public float MovementSpeed;

        private class Baker : Baker<MoveForward>
        {
            public override void Bake(MoveForward authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new _MoveForward { movementSpeed = authoring.MovementSpeed });
            }
        }
    }
}
