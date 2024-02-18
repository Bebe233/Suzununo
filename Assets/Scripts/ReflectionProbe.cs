using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectionProbe : MonoBehaviour
{

    public Transform MirrorPlane;
    public Transform MirrorTarget;

    private void LateUpdate()
    {
        transform.position = GetMirrorMatrix() * MirrorTarget.position;
    }

    [SerializeField]
    float m_Offset;
    public float offest
    {
        get => m_Offset;
        set => m_Offset = value;
    }

    Matrix4x4 GetMirrorMatrix()
    {
        // Setup
        var position = MirrorPlane.position - Vector3.forward * 0.1f;
        var normal = MirrorPlane.forward;
        var depth = -Vector3.Dot(normal, position) - offest;

        // Create matrix
        var mirrorMatrix = new Matrix4x4()
        {
            m00 = (1f - 2f * normal.x * normal.x),
            m01 = (-2f * normal.x * normal.y),
            m02 = (-2f * normal.x * normal.z),
            m03 = (-2f * depth * normal.x),
            m10 = (-2f * normal.y * normal.x),
            m11 = (1f - 2f * normal.y * normal.y),
            m12 = (-2f * normal.y * normal.z),
            m13 = (-2f * depth * normal.y),
            m20 = (-2f * normal.z * normal.x),
            m21 = (-2f * normal.z * normal.y),
            m22 = (1f - 2f * normal.z * normal.z),
            m23 = (-2f * depth * normal.z),
            m30 = 0f,
            m31 = 0f,
            m32 = 0f,
            m33 = 1f,
        };
        return mirrorMatrix;
    }
}
