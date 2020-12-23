using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.02f;

    Material myMaterial;

    Vector2 offset;//movement
    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;

        offset = new Vector2(0f, backgroundScrollSpeed);//y-axis scroll speed
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
