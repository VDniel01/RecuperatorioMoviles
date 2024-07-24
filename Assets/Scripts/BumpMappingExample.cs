using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpMappingExample : MonoBehaviour
{
    public Texture2D normalMap;
    public float bumpIntensity = 1.0f;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null && normalMap != null)
        {
            Material material = new Material(Shader.Find("Standard"));

            material.SetTexture("_BumpMap", normalMap);
            material.SetFloat("_BumpScale", bumpIntensity);

            renderer.material = material;
        }
    }
}
