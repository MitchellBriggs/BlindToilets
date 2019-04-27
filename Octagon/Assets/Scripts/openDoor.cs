using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    private bool open;
    public float positionX;
    public float positionY;
    public float positionZ;
    public float rotationX;
    public float rotationY;
    public float rotationZ;

    // Start is called before the first frame update
    void Start()
    {
        open = true;
    }

    // Update is called once per frame
    public void OnClick()
    {
        if (open)
        {
            transform.localPosition = new Vector3(positionX, positionY, positionZ);
            transform.eulerAngles = new Vector3(rotationX, rotationY, rotationZ);
        }
        else
        {
            transform.localPosition = new Vector3(0, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        open = !open;
    }
}
