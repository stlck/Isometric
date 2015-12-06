using UnityEngine;
using System.Collections;

public class SetStartStats : MonoBehaviour {

    public void SetStrength(int val)
    {
        PlayerPrefs.SetInt("Strength", val);
    }

    public void SetPerception(int val)
    {
        PlayerPrefs.SetInt("Perception", val);
    }

    public void SetFortitude(int val)
    {
        PlayerPrefs.SetInt("Fortitude", val);
    }

    public void SetWillpower(int val)
    {
        PlayerPrefs.SetInt("Willpower", val);
    }

    private int strength = 1;
    private int perception = 1;
    private int fortitude = 1;
    private int willpower = 1;

   /* void OnGUI()
    {
        GUILayout.Space(40);
        GUILayout.Label("strength : " + strength);
        strength = (int)GUILayout.HorizontalSlider(strength, 0, 10, GUILayout.Width(150));
        GUILayout.Label("perception : " + perception);
        perception = (int)GUILayout.HorizontalSlider(perception, 0, 10, GUILayout.Width(150));
        GUILayout.Label("fortitude : " + fortitude);
        fortitude = (int)GUILayout.HorizontalSlider(fortitude, 0, 10, GUILayout.Width(150));
        GUILayout.Label("willpower : " + willpower);
        willpower = (int)GUILayout.HorizontalSlider(willpower, 0, 10, GUILayout.Width(150));

        if (GUILayout.Button("go", GUILayout.Width(150)))
        {
            SetFortitude(fortitude);
            SetWillpower(willpower);
            SetStrength(strength);
            SetPerception(perception);

        }
    }*/

    public void StartLevel()
    {
        Application.LoadLevel("Start");
    }
}
