using System.Collections;
using System.Collections.Generic;
using ModernProgramming;
using UnityEngine;

public class Test : MonoBehaviour
{
    private RSSReader rdr;
    
    void Start()
    {
        // connect to the rss feed and pull it
        rdr = new RSSReader("https://moxie.foxnews.com/feedburner/latest.xml");

        // show feed header
        Debug.Log("Language: " +rdr.headerChannel.language);
        Debug.Log("Title: " +rdr.headerChannel.title);
        Debug.Log("Link: " +rdr.headerChannel.link);
        Debug.Log("Description: " +rdr.headerChannel.description);
        Debug.Log("Docs: " +rdr.headerChannel.docs);
        Debug.Log("Last Build Date: " +rdr.headerChannel.lastBuildDate);
        Debug.Log("Managing Editor: " + rdr.headerChannel.managingEditor);
        Debug.Log("Web Master: " + rdr.headerChannel.webMaster);
        Debug.Log("Generator: " + rdr.headerChannel.generator);
        Debug.Log("Copyright: " + rdr.headerChannel.copyright);
        

        // now display the feed items
        foreach(RSSReader.item itm in rdr.headerChannel.items)
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
