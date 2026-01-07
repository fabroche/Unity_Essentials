using System;
using UnityEngine;

namespace _Unity_Essentials.Scripts.MyScripts.WorldMapViewControllers
{
    public class WorldMapViewController : MonoBehaviour
    {
        public int currentLevel = 0;
        public WorldMapViewMainCharacter player;

        private void Update()
        {
            var canPlayerMoveAhead = Input.GetKeyDown(KeyCode.RightArrow) && currentLevel < transform.childCount - 1;

            if (canPlayerMoveAhead)
            {
                currentLevel++;
                var nextLevelPosition = transform.GetChild(currentLevel).position;
                player.MoveTo(nextLevelPosition);
            }
        }
    }
}