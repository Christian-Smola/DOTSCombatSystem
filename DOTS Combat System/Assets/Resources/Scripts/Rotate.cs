using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class Rotate : MonoBehaviour
{
    public float RotationSpeed;

    private class Baker : Baker<Rotate>
    {
        public override void Bake(Rotate authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Systems._Rotate { rotateSpeed = authoring.RotationSpeed });
        }
    }
}