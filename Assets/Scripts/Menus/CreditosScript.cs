using UnityEngine;
using UnityEngine.UI;

public class CreditosScript : MonoBehaviour
{
    public GameObject creditPanel;
    public GameObject menuPrincipal;
    public Button creditButton;

    void Start()
    {
        creditPanel.SetActive(false);
        creditButton.onClick.AddListener(ShowCreditPanel);
    }

    void ShowCreditPanel()
    {
        menuPrincipal.SetActive(false);
        creditPanel.SetActive(true);
        creditPanel.transform.SetAsLastSibling();
    }
}



