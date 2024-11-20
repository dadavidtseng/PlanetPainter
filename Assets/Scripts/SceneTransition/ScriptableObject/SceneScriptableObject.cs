using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SceneTransition
{
    [CreateAssetMenu(fileName = "SceneData_SO", menuName = "Scenes/SceneData_SO")]
    public class SceneScriptableObject : ScriptableObject
    {
        public AssetReference[] sceneAssets;
    }
}