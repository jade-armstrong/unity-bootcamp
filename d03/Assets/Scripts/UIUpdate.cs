using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour
{
    public GameObject healthText;
    public GameObject energyText;
    Text uiText;
    gameManager game;

    // Start is called before the first frame update
    void Start()
    {
        game = gameObject.GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText = healthText.GetComponent<Text>();
        uiText.text = game.playerHp.ToString();
        uiText = energyText.GetComponent<Text>();
        uiText.text = game.playerEnergy.ToString();
    }
}
