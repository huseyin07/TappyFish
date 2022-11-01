using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    [SerializeField] Sprite metalMedal, bronzMedal, goldMedal, silverMedal;
    Image _img;
    void Start()
    {
        _img=GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        int gameScore = GameManager.gameScore;

        if (gameScore > 0 && gameScore <= 2)
        {
            _img.sprite = metalMedal;
        }
        else if (gameScore > 2 && gameScore <= 6)
        {
            _img.sprite = bronzMedal;
        }
        else if (gameScore > 6 && gameScore <= 10)
        {
            _img.sprite = silverMedal;
        }
        else if (gameScore > 10)
        {
            _img.sprite = goldMedal;
        }
    }
}
