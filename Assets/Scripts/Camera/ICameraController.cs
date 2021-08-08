using UnityEngine;

namespace Game
{
    public interface ICameraController
    {
        void SetFollowTarget(Transform target);
    }
}