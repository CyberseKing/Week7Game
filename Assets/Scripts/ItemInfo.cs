using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public string itemName;
    public int itemValue;
    PlayerControl playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    void OnMouseOver()
    {
        Debug.Log(itemName);
        playerScript.itemText.text = itemName;
        playerScript.hasKey = true;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
