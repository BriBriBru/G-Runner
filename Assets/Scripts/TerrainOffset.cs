using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainOffset : MonoBehaviour
{
    [SerializeField] private float terrainSpeed;
    private Renderer terrainRenderer;
    // Start is called before the first frame update
    void Start()
    {
        terrainRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * terrainSpeed;
        terrainRenderer.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
