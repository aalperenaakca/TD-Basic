using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreTextScript;
    private BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = new BuildManager();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTextScript.text = buildManager.GetCurrentScore().ToString();
    }
}
