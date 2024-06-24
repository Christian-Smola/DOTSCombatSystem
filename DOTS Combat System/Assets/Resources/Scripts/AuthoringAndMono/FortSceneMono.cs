using Unity.Entities;
using UnityEngine;

namespace FortScene
{
    public class FortSceneMono : MonoBehaviour
    {
        public GameObject LegionarySpear;
    }

    public class FortSceneBaker : Baker<FortSceneMono>
    {
        public override void Bake(FortSceneMono authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new FortSceneProperties { LegionarySpear = GetEntity(authoring.LegionarySpear, TransformUsageFlags.Dynamic) });
        }
    }
}
