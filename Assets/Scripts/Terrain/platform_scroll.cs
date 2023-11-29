using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_scroll : MonoBehaviour
{

    public float scroll_speed = 1f;
    private MeshRenderer mesh_renderer;
    private float x_scroll;


    // Start is called before the first frame update
    void Awake()
    {
        mesh_renderer = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        x_scroll= Time.time*scroll_speed;
        Vector2 offset = new Vector2(0f, x_scroll);
        mesh_renderer.sharedMaterial.SetTextureOffset("_MainTex", offset); 

    }
}
