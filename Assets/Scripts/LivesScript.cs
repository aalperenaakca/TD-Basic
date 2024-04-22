using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI livesText;
    private BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = new BuildManager();
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Remaining Lives: " + buildManager.GetLives();
    }
}
