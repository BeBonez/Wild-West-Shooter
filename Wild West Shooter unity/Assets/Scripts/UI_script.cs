using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using TMPro;

public class UI_script : MonoBehaviour
{
    [SerializeField] TMP_Text currentGold;
    [SerializeField] Text currentFakeGold;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentGold.text = "Gold: " + manager.GetComponent<Game_Manager_script>().gold;
        if (manager.GetComponent<Game_Manager_script>().fakeGold > 0)
        {
            currentFakeGold.text = "Fake Gold: " + manager.GetComponent<Game_Manager_script>().fakeGold;
        }  else
        {
            currentFakeGold.text = " ";
        }
    }

    public void Play() {
        SceneManager.LoadScene("Level1");
    }
}
