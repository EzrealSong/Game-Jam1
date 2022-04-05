using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject screen;
    [SerializeField]
    private TextMeshProUGUI hud;
    [SerializeField]
    private PlayerCollectCoin coinCounter;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void CompleteLevel()
    {
        screen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        hud.text = "Score: " + 100*(coinCounter.points);
    }
}
