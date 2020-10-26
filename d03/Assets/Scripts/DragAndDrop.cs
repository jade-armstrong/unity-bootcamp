using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    public GameObject towerImage;
    public GameObject tower;
    towerScript twrScript;
    public GameObject game;
    int energyCost;
    gameManager gameScript;
    private bool isDragging;
    Vector3 mousePos;
    Vector2 towerPos;
    Ray ray;
    RaycastHit2D hit;
    public GameObject price;
    public GameObject dmg;
    public GameObject range;
    public GameObject fireRate;
    Text uiText;
    SpriteRenderer sprite;
    SceneLoader scene;
    public GameObject sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        scene = sceneLoader.GetComponent<SceneLoader>();
        twrScript = tower.GetComponent<towerScript>();
        energyCost = twrScript.energy;
        gameScript = game.GetComponent<gameManager>();
        uiText = price.GetComponent<Text>();
        uiText.text = energyCost.ToString();
        uiText = dmg.GetComponent<Text>();
        uiText.text = "DMG: " + twrScript.damage.ToString();
        uiText = range.GetComponent<Text>();
        uiText.text = "RANGE: " + twrScript.range.ToString();
        uiText = fireRate.GetComponent<Text>();
        uiText.text = "FIRE RATE: " + twrScript.fireRate.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameScript.playerEnergy < energyCost)
        {
            sprite.color = Color.red;
        }
        else sprite.color = Color.white;
        if (isDragging)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            towerPos = (Vector2)mousePos;
            towerImage.transform.position = towerPos;
        }
        
    }

    private void OnMouseDown()
    {
        if (sprite.color == Color.white && !scene.paused)
        {
            isDragging = true;
        }
        
    }

    private void OnMouseUp()
    {
        isDragging = false;
        towerImage.transform.position = new Vector2(-20, 0);
        if (!scene.paused)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit.collider != null && hit.collider.gameObject.tag == "empty" && gameScript.playerEnergy >= energyCost)
            {
                GameObject.Instantiate(tower, hit.collider.gameObject.transform.position, tower.transform.rotation);
                gameScript.playerEnergy -= energyCost;
            }
        }  
    }
}
