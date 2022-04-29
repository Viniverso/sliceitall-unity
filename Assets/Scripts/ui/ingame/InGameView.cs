using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

namespace ui.ingame
{
    public class InGameView : MonoBehaviour
    {
        [SerializeField] private TMP_Text txtScore;


        public void SetScore(int _score)
        {
            txtScore.text = _score.ToString("0000");
        }
    }
}