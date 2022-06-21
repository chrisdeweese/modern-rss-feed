# modern-rss-feed
A simple API to read XML data from RSS feeds.

------

### Setup for Unity 2021.3+

1. Download and import the modern-rss-feed package into your Unity project.
2. Import the `ModernProgramming` namespace into your project file to start using Modern RSS Reader.

------

### Public Methods

#### Getting Elements from Header Channel

`RSSReader.GetHeaderLanguage()` - (string) Returns the header language if there is one.

`RSSReader.GetHeaderTitle()` - (string) Returns the header title if there is one.

`RSSReader.GetHeaderLink()` - (string) Returns the header link if there is one.

`RSSReader.GetHeaderDescription()` - (string) Returns the header description if there is one.

`RSSReader.GetHeaderDocs()` - (string) Returns the header docs if there is one.

`RSSReader.GetHeaderManagingEditor()` - (string) Returns the header managing editor if there is one.

`RSSReader.GetHeaderWebMaster()` - (string) Returns the header web master if there is one.

`RSSReader.GetHeaderLastBuildDate()` - (string) Returns the header's last build date if there is one.

`RSSReader.GetHeaderGenerator()` - (string) Returns the header generator if there is one.

`RSSReader.GetHeaderCopyright()` - (string) Returns the header copyright if there is one.

------

#### Getting Elements from Child Nodes

`RSSReader.GetAllChildNodes()` - (string) Returns all children nodes in the RSS feed.

------

### TO-DO

- image tag support
- itunes tag support for podcasts
- media tag support
- comments tag support
- HTML tag formatting
- Create a demo scene with pre-made rss feeds
- Test backwards compatability