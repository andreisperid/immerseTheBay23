using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class LiquidCup : MonoBehaviour
{
    public Color topColor = Color.white;
    public Color middleColor = Color.yellow;
    public Color bottomColor = Color.black;
    public float topHeight = 0.5f;
    public float middleHeight = 0.3f;

    private Renderer _renderer;
    private Material _material;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
    }

    void Update()
    {
        _material.SetColor("_TopColor", topColor);
        _material.SetColor("_MiddleColor", middleColor);
        _material.SetColor("_BottomColor", bottomColor);
        _material.SetFloat("_TopHeight", topHeight);
        _material.SetFloat("_MiddleHeight", middleHeight);
    }
}
