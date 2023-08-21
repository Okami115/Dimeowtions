using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Menu
{
    public class UIManager : MonoBehaviour
    {
      [SerializeField] private GameObject menu;

      private void Start()
      {
          ToggleCanvas(true);
      }

      public void ToggleCanvas(bool active)
      {
          menu.SetActive(active);
      }
    }

}
