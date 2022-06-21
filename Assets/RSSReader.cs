using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace ModernProgramming
{
    public class RSSReader : MonoBehaviour
    {
        /// <summary>
        /// This is the first XML &lt;channel> tag in the RSS document, also known as the header. 
        /// </summary>
        public channel headerChannel;
        
        private XmlTextReader reader;
        private XmlDocument rssDoc;
        private XmlNode nodeRss;
        private XmlNode nodeChannel;
        private XmlNode nodeItem;
        
        /// <summary>
        /// Struct that contains all possible XML tags found in the &lt;channel> tag's child nodes.
        /// </summary>
        public struct channel
        {
            public string language;
            public string title;
            public string link;
            public string description;
            public string docs;
            public string managingEditor;
            public string webMaster;
            public string lastBuildDate;
            public string generator;
            public string copyright;
            
            // List of RSS items in the feed.
            public List<item> items;
        }
        
        /// <summary>
        /// Struct that contains all possible XML tags found in the item's child nodes.
        /// </summary>
        public struct item
        {
            public string title;
            public string category;
            public string creator;
            public string guid;
            public string link;
            public string pubDate;
            public string description;
        }
        
        /// <summary>
        /// Constructor that rebuilds the RSS document locally from the URL provided.
        /// </summary>
        /// <param name="feedURL">RSS URL to use.</param>
        public RSSReader(string feedURL)
        {
            // Create a new header channel.
            headerChannel = new channel();
            
            // Create the channel's items list.
            headerChannel.items = new List<item>();
            
            // Load the XML document from the URL.
            reader = new XmlTextReader(feedURL);
            rssDoc = new XmlDocument();
            rssDoc.Load(reader);
            
            // Loop through the child nodes to find the <rss> tag.
            if (rssDoc != null)
            {
                for (int i = 0; i < rssDoc.ChildNodes.Count; i++)
                {
                    if (rssDoc.ChildNodes[i].Name == "rss")
                    {
                        // <rss> tag was found.
                        nodeRss = rssDoc.ChildNodes[i];
                        break;
                    }
                }
            }
            else
            {
                Debug.LogWarning("Modern RSS Reader - Error loading RSS document! Ensure URL is valid!");
                return;
            }
            
            // Loop through the child nodes to find the <channel> tag.
            if (nodeRss != null)
            {
                for (int i = 0; i < nodeRss.ChildNodes.Count; i++)
                {
                    if (nodeRss.ChildNodes[i].Name == "channel")
                    {
                        // <channel> tag was found.
                        nodeChannel = nodeRss.ChildNodes[i];
                        break;
                    }
                }
            }
            else
            {
                Debug.LogWarning("Modern RSS Reader - Error locating <rss> tag in document! Ensure the page's XML is valid!");
                return;
            }
            
            // Build our channel struct with the information we found in the <channel> tag's child nodes.
            if (nodeChannel != null)
            {
                // Build our channel's header information.
                if (nodeChannel["language"] != null) headerChannel.language = nodeChannel["language"].InnerText;
                if (nodeChannel["title"] != null) headerChannel.title = nodeChannel["title"].InnerText;
                if (nodeChannel["link"] != null) headerChannel.link = nodeChannel["link"].InnerText;
                if (nodeChannel["description"] != null) headerChannel.description = nodeChannel["description"].InnerText;
                if (nodeChannel["docs"] != null) headerChannel.docs = nodeChannel["docs"].InnerText;
                if (nodeChannel["managingEditor"] != null) headerChannel.managingEditor = nodeChannel["managingEditor"].InnerText;
                if (nodeChannel["webMaster"] != null) headerChannel.webMaster = nodeChannel["webMaster"].InnerText;
                if (nodeChannel["lastBuildDate"] != null) headerChannel.lastBuildDate = nodeChannel["lastBuildDate"].InnerText;
                if (nodeChannel["generator"] != null) headerChannel.generator = nodeChannel["generator"].InnerText;
                if (nodeChannel["copyright"] != null) headerChannel.copyright = nodeChannel["copyright"].InnerText;
                
                // Build our channel's items information.
                for (int i = 0; i < nodeChannel.ChildNodes.Count; i++)
                {
                    if (nodeChannel.ChildNodes[i].Name == "item")
                    {
                        // Set our item node to this child item.
                        nodeItem = nodeChannel.ChildNodes[i];
                        
                        // Create a new item and fill it with the data we found.
                        item newItem = new item();
                        if (nodeItem.InnerXml.Contains("title")) newItem.title = nodeItem["title"].InnerText;
                        if (nodeItem.InnerXml.Contains("link")) newItem.link = nodeItem["link"].InnerText;
                        if (nodeItem.InnerXml.Contains("category")) newItem.category = nodeItem["category"].InnerText;
                        if (nodeItem.InnerXml.Contains("dc:creator")) newItem.creator = nodeItem["dc:creator"].InnerText;
                        if (nodeItem.InnerXml.Contains("pubDate")) newItem.pubDate = nodeItem["pubDate"].InnerText;
                        if (nodeItem.InnerXml.Contains("description")) newItem.description = nodeItem["description"].InnerText;
                        
                        // Add the item to the channel items list.
                        headerChannel.items.Add(newItem);
                    }
                }
            }
            else
            {
                Debug.LogWarning("Modern RSS Reader - Error locating <channel> tag in document! Ensure the page's XML is valid!");
                return;
            }
        }
    }   
}
