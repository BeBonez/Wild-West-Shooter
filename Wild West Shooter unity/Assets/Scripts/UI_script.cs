using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_script : MonoBehaviour
{
    [SerializeField] Text currentGold;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentGold.text = "Gold: " + manager.GetComponent<Game_Manager_script>().gold;
    }

    public void Play() {
        SceneManager.LoadScene("Level1");
    }
}
