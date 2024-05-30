using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
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
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<_MoveForward>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            MoveCubeJob job = new MoveCubeJob { deltaTime = SystemAPI.Time.DeltaTime };

            job.ScheduleParallel();
        }

        [BurstCompile]
        public partial struct MoveCubeJob : IJobEntity
        {
            public float deltaTime;

            public void Execute(ref LocalTransform transform, in _MoveForward move)
            {
                transform = transform.RotateY(move.movementSpeed * deltaTime);
            }
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
