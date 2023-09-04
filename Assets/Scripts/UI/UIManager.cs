using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Menu
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject settingsPanel;

        private void Start()
        {
            ToggleMenuCanvas(true);
            //Time.timeScale = 0f;
        }

        public void ToggleMenuCanvas(bool active)
        {
            menuPanel.SetActive(active);
            //Time.timeScale = 1f;
        }

        public void ToggleSetingsCanvas(bool active)
        {
            settingsPanel.SetActive(active);
            //Time.timeScale = 1f;
        }
    }

}
