using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceShaderInMiniMapCamera : MonoBehaviour
{
    [SerializeField] private Camera _miniMapCamera;

    private void Awake()
    {
        _miniMapCamera.SetReplacementShader(Shader.Find("Unlit/Color"), "RenderType");
    }
}
