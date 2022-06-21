using System.Collections;
using System.Collections.Generic;
using ModernProgramming;
using UnityEngine;

public class RSSTester : MonoBehaviour
{
    private RSSReader reader;
    
    void Start()
    {
        // Connect to the RSS feed
        reader = new RSSReader("https://blog.unity.com/feed/games");

        // Log the feed's header
        Debug.Log("Language: " + reader.headerChannel.language);
        Debug.Log("Title: " + reader.headerChannel.title);
        Debug.Log("Link: " + reader.headerChannel.link);
        Debug.Log("Description: " + reader.headerChannel.description);
        Debug.Log("Docs: " + reader.headerChannel.docs);
        Debug.Log("Last Build Date: " + reader.headerChannel.lastBuildDate);
        Debug.Log("Managing Editor: " +  reader.headerChannel.managingEditor);
        Debug.Log("Web Master: " + reader.headerChannel.webMaster);
        Debug.Log("Generator: " + reader.headerChannel.generator);
        Debug.Log("Copyright: " + reader.headerChannel.copyright);
        

        // Log the feed's items
        foreach (RSSReader.item itm in reader.headerChannel.items)
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
