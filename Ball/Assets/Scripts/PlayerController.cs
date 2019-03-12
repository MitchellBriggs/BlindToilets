using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public Text countText;
    public Text winText;
    public float speed;
    public int count;
    public int winAmount;
    private Vector3 startPos;

    // Start is called before the first frame update
    public void StartUp()
    {
        SetWinAmount();
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        startPos = transform.position;
    }

    public void SetWinAmount()
    {
        winAmount = GameObject.Find("PickUps").GetComponent<PickUpController>().pickups;
    }

    // Update is called once per frame
    public void ToStart()
    {
        transform.position = startPos;
    }

    void  FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            Destroy(other.gameObject);
            count++;
            SetCountText();
        }
    }
    
    public void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count >= winAmount)
        {
            winText.text = "You Win!";
        }
    }
}
