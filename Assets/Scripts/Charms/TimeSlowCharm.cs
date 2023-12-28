using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlowCharm : MonoBehaviour, CharmUse
{
   public void end()
    {
        GlobalVarsAbl.Instance.slowMo = false;
        Time.timeScale = 1f;
    }

    public void use()
    {
        GlobalVarsAbl.Instance.slowMo = true;
        Time.timeScale = 0.5f;
    }
}
