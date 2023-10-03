using System.Collections;
using UnityEngine;

public class CameraMirror : MonoBehaviour
{
    [SerializeField]
    private Camera cameraToMirror;

    void OnPreCull()
    {
        Matrix4x4 scale = Matrix4x4.Scale(new Vector3(-1, 1, 1));
        cameraToMirror.ResetWorldToCameraMatrix();
        cameraToMirror.ResetProjectionMatrix();
        cameraToMirror.projectionMatrix = cameraToMirror.projectionMatrix * scale;
    }
    void OnPreRender()
    {
        GL.invertCulling = true;
    }
    void OnPostRender()
    {
        GL.invertCulling = false;
    }
}