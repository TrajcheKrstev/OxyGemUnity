using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class UnderwaterEffect : MonoBehaviour
{
    public Material material;
    [Range(0.001f, 0.1f)]
    public float pixelOffset;
    [Range(0.1f, 20f)]
    public float noiseScale;
    [Range(0.1f, 20f)]
    public float noiseFrequency;
    [Range(0.1f, 30f)]
    public float noiseSpeed;
    public float depthStart;
    public float depthDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        material.SetFloat("_NoiseFrequency", noiseFrequency);
        material.SetFloat("_NoiseSpeed", noiseSpeed);
        material.SetFloat("_NoiseScale", noiseScale);
        material.SetFloat("_PixelOffset", pixelOffset);
        material.SetFloat("_DepthStart", depthStart);
        material.SetFloat("_DepthDistance", depthDistance);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
}
