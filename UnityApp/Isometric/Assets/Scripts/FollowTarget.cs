using System;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public bool FollowMyPlayer = false;

    public Transform target;
    public Vector3 offset = new Vector3(0f, 7.5f, 0f);

    void Start()
    {
        if (target == null)
            target = MyPlayer.Instance.transform;
    }

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
