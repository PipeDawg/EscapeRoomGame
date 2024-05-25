using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVBackground : MonoBehaviour
{
    public Light TVLight;
    private float lightIntensity = 2; // Start value is 2

    void Update()
    {
        lightIntensity += Random.Range(-0.15f, 0.15f); // Either increases or decreases light intensity by a very small amount each frame
        lightIntensity = Mathf.Clamp(lightIntensity, 1, 5); // Stops the intensity from going too high or low so the TV doesn't turn off or turn into the sun
        lightIntensity = Mathf.Round(lightIntensity * 4) / 4; // Makes the intensity work in increments of .25. This makes the flickering look better by eliminating all the tiny flickers, and making it update every 1-5 frames, instead of every frame
        TVLight.intensity = lightIntensity; // Updates the intensity
    }
}
