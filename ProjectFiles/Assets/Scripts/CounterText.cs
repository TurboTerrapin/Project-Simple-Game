using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterText : MonoBehaviour
{
    public Canvas canvas;
    public TMPro.TextMeshProUGUI textMesh;
    public PlayerController pc;
    public int textType;
    RectTransform rectTransformCanvas;

    // Start is called before the first frame update
    void Start()
    {
        rectTransformCanvas = canvas.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (textType == 0)
        {
            textMesh.rectTransform.anchoredPosition = new Vector2(rectTransformCanvas.position.x - 20, rectTransformCanvas.position.y - 20);
            textMesh.text = "Coins: " + pc.coins;
        }
        if (textType == 1)
        {
            textMesh.rectTransform.anchoredPosition = new Vector2(rectTransformCanvas.position.x - 20, rectTransformCanvas.position.y - 40);
            textMesh.text = "Lives: " + pc.lives;
        }
    }
}
