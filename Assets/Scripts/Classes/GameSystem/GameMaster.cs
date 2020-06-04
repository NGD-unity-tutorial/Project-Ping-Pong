using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameMaster.core
{

    public class GameMaster : MonoBehaviour
    {
        [SerializeField]
        float roundTime;
        [SerializeField]
        float[] scores;
        
        void FixedUpdate()
        {
            if (roundTime <= 0) RoundEnd();
            Clock(-Time.deltaTime);
        }

        void Goal(bool isPlayer1, int value)
        {
            // player1 : score[0] get score otherwise enemy or player2 : score[1] get score.
            scores[isPlayer1 ? 0 : 1] += value;
        }

        void Clock(float time)
        {
            roundTime += time;
        }

        void RoundEnd()
        {
            //Maybe route to menu in the feature.
        }
    }

}