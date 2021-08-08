using UnityEngine;

namespace Game
{
    public class DataManager : IDataManager
    {
        public GameObject LoadPrefab(string path)
        {
            return Resources.Load(path) as GameObject;
        }

        public ScriptableObject LoadAsset(string path)
        {
            return Resources.Load(path) as ScriptableObject;
        }

        public void OnDelete() { }
    }
}