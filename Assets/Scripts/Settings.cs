using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject settingMenu;
    public float DelayTime;

    public void ToggleSettingsPage()
    {
        if (!settingMenu.activeInHierarchy)
        {
            settingMenu.SetActive(true);
        }
        else
        {
            settingMenu.SetActive(false);
        }
    }

    public void ToggleMenuDelay()
    {
        StartCoroutine(Delay(DelayTime));
    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (!settingMenu.activeInHierarchy)
        {
            settingMenu.SetActive(true);
        }
        else
        {
            settingMenu.SetActive(false);
        }

    }

}
