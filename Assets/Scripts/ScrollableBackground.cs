using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollableBackground : MonoBehaviour
{
    private Renderer quadRenderer;

    public float scrollSpeed = 0.25f;

    void Start()
    {
        quadRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 textureOffset = new Vector2(0, Time.time * scrollSpeed);
        quadRenderer.material.mainTextureOffset = textureOffset;
    }
}
