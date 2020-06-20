using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject settingMenu;

    public void ToggleSettingsPage()
    {
        if (!settingMenu.activeInHierarchy)
            settingMenu.SetActive(true);
        else
            settingMenu.SetActive(false);
    }

}
