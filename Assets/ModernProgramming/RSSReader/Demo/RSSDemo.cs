using System.Collections;
using System.Collections.Generic;
using ModernProgramming;
using UnityEngine;
using UnityEngine.UI;

public class RSSDemo : MonoBehaviour
{
    [Header("RSS/XML Feed URL")]
    public string URL;

    [Header("Scroll View Elements")]
    public Transform content;
    [SerializeField] private GameObject textObject;
    
    [Header("Demo Labels")]
    public Text languageLabel;
    public Text titleLabel;
    public Text linkLabel;
    public Text descriptionLabel;
    public Text docsLabel;
    public Text lastBuildDateLabel;
    public Text managingEditorLabel;
    public Text webMasterLabel;
    public Text generatorLabel;
    public Text copyrightLabel;
    
    private RSSReader rss;
    
    void Start()
    {
        // Connect to the RSS feed
        rss = new RSSReader(URL);

        // Create the feed's header
        languageLabel.text = "Language: " + rss.GetLanguage();
        titleLabel.text = "Title: " + rss.GetTitle();
        linkLabel.text = "Link: " + rss.GetLink();
        descriptionLabel.text = "Description: " + rss.GetDescription();
        docsLabel.text = "Docs: " + rss.GetDocs();
        lastBuildDateLabel.text = "Last Build Date: " + rss.GetLastBuildDate();
        managingEditorLabel.text = "Managing Editor: " + rss.GetManagingEditor();
        webMasterLabel.text = "Web Master: " + rss.GetWebMaster();
        generatorLabel.text = "Generator: " + rss.GetGenerator();
        copyrightLabel.text = "Copyright: " + rss.GetCopyright();
        
        // Create the feed's items
        foreach (RSSReader.item rssItem in rss.GetRSSItems())
        {
            Instantiate(textObject, content).GetComponent<Text>().text = "Item Title: " + rssItem.title;
            Instantiate(textObject, content).GetComponent<Text>().text = "Item Category: " + rssItem.category;
            Instantiate(textObject, content).GetComponent<Text>().text = "Item Creator: " + rssItem.creator;
            Instantiate(textObject, content).GetComponent<Text>().text = "Item GUID: " + rssItem.guid;
            Instantiate(textObject, content).GetComponent<Text>().text = "Item Link: " + rssItem.link;
            Instantiate(textObject, content).GetComponent<Text>().text = "Item Publication Date: " + rssItem.pubDate;
            Instantiate(textObject, content).GetComponent<Text>().text = "Item Description: " + rssItem.description;
        }
    }
}
