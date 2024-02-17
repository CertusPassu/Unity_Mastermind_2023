
using UnityEngine;

public class NoDraggablePawnState : IPawnState
{
    public void Move(Transform transform)
    {
        //do nothing
    }

    public void Release(Transform transform, Vector3 positionToRelease)
    {
        throw new System.NotImplementedException();
    }
}

