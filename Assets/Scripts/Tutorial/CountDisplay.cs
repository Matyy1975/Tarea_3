using UnityEngine;
using UnityEngine.UI;

public class CountDisplay : MonoBehaviour
{
    public int count = 0;
    public Text countText;

    private void Update()
    {
        countText.text = count.ToString();
    }
}
