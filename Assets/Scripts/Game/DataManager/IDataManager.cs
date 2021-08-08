using UnityEngine;

namespace Game
{
    public interface IDataManager
    {
        GameObject LoadPrefab(string path);
        ScriptableObject LoadAsset(string path);
        void OnDelete();
    }
}