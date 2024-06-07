using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    public struct _Move : IComponentData
    {
        public float movementSpeed;
        public float3 movementDirection;
    }

    public struct _Rotate : IComponentData
    {
        public float rotateSpeed;
    }

    public partial struct MovementSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<_Move>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            //MoveCubeJob job = new MoveCubeJob { deltaTime = SystemAPI.Time.DeltaTime };

            //job.ScheduleParallel();
        }

        [BurstCompile]
        public partial struct MoveCubeJob : IJobEntity
        {
            public float deltaTime;

            public void Execute(ref LocalTransform transform, in _Move move)
            {
                transform = transform.RotateY(move.movementSpeed * deltaTime);
            }
        }
    }

    public partial struct RotateSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<_Rotate>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            RotateCubeJob job = new RotateCubeJob { deltaTime = SystemAPI.Time.DeltaTime };

            job.ScheduleParallel();
        }

        [BurstCompile]
        public partial struct RotateCubeJob : IJobEntity
        {
            public float deltaTime;

            public void Execute(ref LocalTransform transform, in _Rotate rotate)
            {
                transform = transform.RotateY(rotate.rotateSpeed * deltaTime);
            }
        }
    }
}
