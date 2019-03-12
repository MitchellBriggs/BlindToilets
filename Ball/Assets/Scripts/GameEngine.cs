using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class GameEngine : MonoBehaviour
{
    public GameObject player;
    public GameObject pickUps;
    private int level;

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        GameObject.Find("PickUps").GetComponent<PickUpController>().StartUp();
        GameObject.Find("Player").GetComponent<PlayerController>().StartUp();
        ShowLevel();
        Invoke("HideLevel", 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().count == GameObject.Find("Player").GetComponent<PlayerController>().winAmount)
        {
            level++;
            GameObject.Find("Player").GetComponent<PlayerController>().count = 0;
            Invoke("Reset", 4);
        }
    }
    void Reset()
    {
        GameObject.Find("PickUps").GetComponent<PickUpController>().StartUp();
        GameObject.Find("Player").GetComponent<PlayerController>().ToStart();
        GameObject.Find("Player").GetComponent<PlayerController>().SetWinAmount();
        ShowLevel();
        GameObject.Find("Player").GetComponent<PlayerController>().SetCountText();
        Invoke("HideLevel", 2);
    }

    void HideLevel()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().winText.text = " ";
    }

    void ShowLevel()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().winText.text = "Level " + level.ToString();
    }
}
