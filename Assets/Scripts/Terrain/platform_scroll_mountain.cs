using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_scroll_mountain : MonoBehaviour
{

    public float scroll_speed = 0.5f;
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
        x_scroll= Time.time*scroll_speed*-1;
        Vector2 offset = new Vector2(x_scroll, 0f);
        mesh_renderer.sharedMaterial.SetTextureOffset("_MainTex", offset); 

    }
}
