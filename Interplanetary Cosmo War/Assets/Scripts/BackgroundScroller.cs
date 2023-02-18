using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : HaoMonoBehaviour
{
    [SerializeField] protected float background_ScrollSpeed = 0.05f;
    Material myMaterial;
    Vector2 offSet;

    protected override void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0, background_ScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offSet * offSet;
    }
}
