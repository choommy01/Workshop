using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryPanel : MonoBehaviour
{
    public Image selectIcon;
    public TMP_Text descriptionText;
    public Transform rightPanelTransform;
    public GameObject itemButtonPrefab;

    public void OnOpen()
    {
        for (int i = rightPanelTransform.childCount - 1; i >= 0; i--)
        {
            Destroy(rightPanelTransform.GetChild(i).gameObject);
        }
        for(int i = 0;i < InventoryManager.instance.InventoryList.Count; i++)
        {
            GameObject ItemButtonObj = Instantiate(itemButtonPrefab,rightPanelTransform);
            ItemButton itemButtonComp = ItemButtonObj.GetComponent<ItemButton>();
            itemButtonComp.data = InventoryManager.instance.InventoryList[i];
            itemButtonComp.icon.sprite = itemButtonComp.data.itemIcon;
            Button button = ItemButtonObj.GetComponent<Button>();
            button.onClick.AddListener(() => 
            {
                selectIcon.sprite = itemButtonComp.data.itemIcon;
                descriptionText.text = itemButtonComp.data.description;
            });
        }
    }
}
