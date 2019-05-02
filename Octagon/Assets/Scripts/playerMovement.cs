using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gvr;

public class playerMovement : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 currentPosition;
    private bool startedMoving;
    private float speed;

    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        startedMoving = false;
        speed = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (GvrControllerInput.IsTouching)
        {
            if(!startedMoving)
            {
                startPosition = GvrControllerInput.TouchPos;
                currentPosition = GvrControllerInput.TouchPos;
                startedMoving = true;
                speed = 2;
            }
            else
            {
                currentPosition = GvrControllerInput.TouchPos;
                Vector3 camF = cam.forward;
                Vector3 camR = cam.right;

                camF.y = 0;
                camR.y = 0;
                camF = camF.normalized;
                camR = camR.normalized;
                print(camF);

                float xdif = currentPosition.x - startPosition.x;
                float zdif = startPosition.y - currentPosition.y;
                
                transform.position += (camF*zdif + camR*xdif)*Time.deltaTime*speed;
            }
        }
        else
        {
            startedMoving = false;
            speed = 0;
        }
    }
}
