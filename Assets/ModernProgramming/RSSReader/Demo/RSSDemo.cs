using System.Collections;
using System.Collections.Generic;
using ModernProgramming;
using UnityEngine;
using UnityEngine.UI;

public class RSSDemo : MonoBehaviour
{
    [Header("RSS/XML Feed URL")]
    public string URL;
    
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
        

        // Log the feed's items
        foreach (RSSReader.item itm in rss.GetRSSItems())
        {
            Debug.Log("Item Title: " + itm.title);
            Debug.Log("Item Category: " + itm.category);
            Debug.Log("Item Creator: " + itm.creator);
            Debug.Log("Item guid: " + itm.guid);
            Debug.Log("Item link: " + itm.link);
            Debug.Log("Item publication date: " + itm.pubDate);
            Debug.Log("Item description: " + itm.description);
        }
    }
}
