using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class marker : MonoBehaviour
{
    [SerializeField] private Transform tip;
    [SerializeField] private int penSize = 5;

    private Renderer rend;
    private Color[] colors;
    private float tipHeight;

    private RaycastHit touch;
    private WhiteBoard whiteboard;
    private Vector2 touchPos;
    private Vector2 lastTouchPosition;
    private bool touchLastFrame;
    private Quaternion lastTouchRot;

    // Start is called before the first frame update
    void Start()
    {
        rend = tip.GetComponent<Renderer>();
        colors = Enumerable.Repeat(rend.material.color, penSize * penSize).ToArray();
        tipHeight = tip.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        Draw();
    }

    private void Draw()
    {
        if (Physics.Raycast(tip.position, transform.up, out touch, tipHeight))
        {
            if (touch.transform.CompareTag("Whiteboard"))
            {
                if (whiteboard == null)
                {
                    whiteboard = touch.transform.GetComponent<WhiteBoard>();
                }

                touchPos = new Vector2(touch.textureCoord.x, touch.textureCoord.y);

                var x = (int)(touchPos.x * whiteboard.textureSize.x - (penSize / 2));
                var y = (int)(touchPos.y * whiteboard.textureSize.y - (penSize / 2));

                if (y < 0 || y > whiteboard.textureSize.y || x < 0 || x > whiteboard.textureSize.x)
                {
                    return;
                }
                
                if (touchLastFrame)
                {
                    whiteboard.texture.SetPixels(x, y, penSize, penSize, colors);

                    for (float f = 0.01f; f < 1.00f; f += 0.01f)
                    {
                        var lerpX = (int)Mathf.Lerp(lastTouchPosition.x, x, f);
                        var lerpY = (int)Mathf.Lerp(lastTouchPosition.y, y, f);

                        whiteboard.texture.SetPixels(lerpX, lerpY, penSize, penSize, colors);

                    }

                    transform.rotation = lastTouchRot;

                    whiteboard.texture.Apply();
                }

                lastTouchPosition = new Vector2(x, y);
                lastTouchRot = transform.rotation;
                touchLastFrame = true;
                return;
            }
        }

        whiteboard = null;
        touchLastFrame = false;
    }
}
