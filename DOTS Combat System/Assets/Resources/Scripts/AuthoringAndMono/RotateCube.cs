using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class RotateCube : MonoBehaviour
{
    public float RotationSpeed;

    private class Baker : Baker<RotateCube>
    {
        public override void Bake(RotateCube authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new CubeSystems._Rotate { rotateSpeed = authoring.RotationSpeed });
        }
    }
}