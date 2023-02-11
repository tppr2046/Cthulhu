using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Missiles
{
    public class Wellcome : MonoBehaviour
    {

        public GameObject SpawnButtons;
        public GameObject MissileButtons;
        public GameObject panel;

        private void Start()
        {
            panel.SetActive(true);
            SpawnButtons.SetActive(false);
            MissileButtons.SetActive(false);
        }
        public void StartButton()
        {
            SpawnButtons.SetActive(true);
            MissileButtons.SetActive(true);
            panel.SetActive(false);
        }
    }
}
