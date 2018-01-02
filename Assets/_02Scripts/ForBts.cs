using UnityEngine;
using System.Collections;

public class ForBts : MonoBehaviour
{
    private int count = 0;

    public void OnClick(string str)
    {
        switch (str)
        {
            case "coat":
                if (count == 0)
                {
                    AvatarSystem.instance.ChangeMesh("coat", "001");
                    count = 1;
                }
                else
                {
                    AvatarSystem.instance.ChangeMesh("coat", "003");
                    count = 0;
                }
                break;
            case "hair":
                if (count == 0)
                {
                    AvatarSystem.instance.ChangeMesh("hair", "001");
                    count = 1;
                }
                else
                {
                    AvatarSystem.instance.ChangeMesh("hair", "003");
                    count = 0;
                }
                break;
            case "hand":
                if (count == 0)
                {
                    AvatarSystem.instance.ChangeMesh("hand", "001");
                    count = 1;
                }
                else
                {
                    AvatarSystem.instance.ChangeMesh("hand", "003");
                    count = 0;
                }
                break;
            case "head":
                if (count == 0)
                {
                    AvatarSystem.instance.ChangeMesh("head", "001");
                    count = 1;
                }
                else
                {
                    AvatarSystem.instance.ChangeMesh("head", "003");
                    count = 0;
                }
                break;
            case "pant":
                if (count == 0)
                {
                    AvatarSystem.instance.ChangeMesh("pant", "001");
                    count = 1;
                }
                else
                {
                    AvatarSystem.instance.ChangeMesh("pant", "003");
                    count = 0;
                }
                break;
            case "foot":
                if (count == 0)
                {
                    AvatarSystem.instance.ChangeMesh("foot", "001");
                    count = 1;
                }
                else
                {
                    AvatarSystem.instance.ChangeMesh("foot", "003");
                    count = 0;
                }
                break;
        }
    }
}
