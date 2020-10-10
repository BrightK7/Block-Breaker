using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //config param
    [SerializeField] float WidthUnit = 16f;
    [SerializeField] float MaxX = 15f;
    [SerializeField] float MinX = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition.x / Screen.width * WidthUnit);
        float MousePos_x = Input.mousePosition.x / Screen.width * WidthUnit;
        Vector2 PaddlePos = new Vector2(MousePos_x, transform.position.y);
        PaddlePos.x = Mathf.Clamp(MousePos_x, MinX, MaxX);
        transform.position = PaddlePos;
    }

    public void UpdatePaddleWidth(float newWithSize)
    {
        Vector3 newLocalScale = new Vector3(newWithSize, 1f, 1f);
        transform.localScale = newLocalScale;
    }
}
