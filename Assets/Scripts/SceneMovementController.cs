using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMovementController : MonoBehaviour
{

    [SerializeField]private Renderer renderer;
    private Material currentMaterial;
    [SerializeField] private float offsetIncrement;
    [SerializeField] private float offset;
    [SerializeField] public float speed;
    private int renderOrder = -10;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.sortingOrder = renderOrder;
        currentMaterial = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += offsetIncrement;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
    }
}
