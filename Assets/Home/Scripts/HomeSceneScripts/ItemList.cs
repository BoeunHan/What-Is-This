using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate ()
        {
            OnClick(param);
        });
    }
}

public class ItemList : MonoBehaviour
{
    [Serializable]
    public struct MyPumpkin
    {
        public Sprite pumpkin;
    }

    [SerializeField] MyPumpkin[] allPumpkins;

    private struct Item
    {
        int id;
        string word;
        public Item(int id, string word)
        {
            this.id = id;
            this.word = word;
        }
        public string getWord() { return word; }
        public int getId() { return id; }
    }
    private Item[] itemList;
    void getItemList()
    {
        itemList = new Item[16];
        itemList[0] = new Item(0, "hello");
        itemList[1] = new Item(1, "���");
        itemList[2] = new Item(2, "���");
        itemList[3] = new Item(3, "���");
        itemList[4] = new Item(4, "����");
        itemList[5] = new Item(5, "���콺");
        itemList[6] = new Item(6, "����");
        itemList[7] = new Item(7, "��");
        itemList[8] = new Item(8, "hello");
        itemList[9] = new Item(9, "���");
        itemList[10] = new Item(10, "���");
        itemList[11] = new Item(11, "���");
        itemList[12] = new Item(12, "����");
        itemList[13] = new Item(13, "���콺");
        itemList[14] = new Item(14, "����");
        itemList[15] = new Item(15, "��");
    }
    void Start()
    {
        getItemList();
        DrawUI();
    }
    void DrawUI()
    {
        GameObject itemTemplate = transform.GetChild(0).gameObject;
        GameObject g;


        int N = itemList.Length;

        for (int i = 0; i < N; i++)
        {
            g = Instantiate(itemTemplate, transform);
            Sprite pumpkin = allPumpkins[itemList[i].getId() % 4].pumpkin;

            g.transform.GetChild(0).GetComponent<Image>().sprite = pumpkin;

            g.transform.GetChild(1).GetComponent<Text>().text = itemList[i].getWord();

            g.GetComponent<Button>().AddEventListener(i, itemClicked);
        }

        Destroy(itemTemplate);

    }

    void itemClicked(int itemIndex)
    {
        
    }

}
