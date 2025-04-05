using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class ShowAbilityIcon : MonoBehaviour
{
    GrowlAbility growlAbilityScript;
    ZoomiesAbility zoomiesAbilityScript;

    [SerializeField] Image ZoomiesIcon;
    [SerializeField] Image GrowlIcon;
    void Start()
    {
        //ZoomiesIcon.gameObject.SetActive(false);
        GrowlIcon.gameObject.SetActive(false);
        //ZoomiesIcon = GetComponent<Image>();
        //GrowlIcon = GetComponent<Image>();

        //Color z = ZoomiesIcon.color;
        //Color g = GrowlIcon.color;

        //z.a = 80;
        //g.a = 80;

        //ZoomiesIcon.color = z;
        //GrowlIcon.color = g;
    }

    // Update is called once per frame
    void Update()
    {
       //if (Input.GetKeyDown(KeyCode.Space))
       //{
       //     ZoomiesIcon.gameObject.SetActive(true);
       //}
    }
}
