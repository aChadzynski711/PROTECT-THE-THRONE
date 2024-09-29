using System.Collections;
using UnityEngine;

public class DayCycle : MonoBehaviour
{

    private bool isDay = true;


    //----------------------------------------------------------------------------------------------------------------------------//


    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(DayNightCycle());
    }


    // Main coroutine for day and night cycling
    private IEnumerator DayNightCycle()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(1);

            // Day Time
            if (isDay)
            {
                //Debug.Log("Day Cycle Begin");

                DemonManager.Instance.GenerateGold();
            }
            // Night Time
            else
            {
                //Debug.Log("Night Cycle Begin");
            }

        }

        isDay = !isDay;
        StartCoroutine(DayNightCycle());
    }


    // Function call to pause/start the cycle in case I include something that I want the game to pause on
    public void PauseCycle()
    {
        StopCoroutine(DayNightCycle());
    }


    public void StartCycle()
    {
        StartCoroutine(DayNightCycle());
    }
}
