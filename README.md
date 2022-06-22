# modern-rss-feed v1.0
A simple API to read XML data from RSS feeds.

------

### Setup for Unity 2021.3+

1. Download and import the modern-rss-feed package into your Unity project.
2. Import the `ModernProgramming` namespace into your project file to start using Modern RSS Reader.
3. See the demo scene for examples on implementation.

------

### Public Methods

#### Getting Elements from Header Channel

`RSSReader.GetLanguage()` - (string) Returns the header language if there is one.

`RSSReader.GetTitle()` - (string) Returns the header title if there is one.

`RSSReader.GetLink()` - (string) Returns the header link if there is one.

`RSSReader.GetDescription()` - (string) Returns the header description if there is one.

`RSSReader.GetDocs()` - (string) Returns the header docs if there is one.

`RSSReader.GetManagingEditor()` - (string) Returns the header managing editor if there is one.

`RSSReader.GetWebMaster()` - (string) Returns the header web master if there is one.

`RSSReader.GetLastBuildDate()` - (string) Returns the header's last build date if there is one.

`RSSReader.GetGenerator()` - (string) Returns the header generator if there is one.

`RSSReader.GetCopyright()` - (string) Returns the header copyright if there is one.

------

#### Getting Child Items

`RSSReader.GetRSSItems()` - (List<item>) Returns the RSS child items if there are any.

`RSSReader.item.title` - (string) Title of the current item in the list.

`RSSReader.item.category` - (string) Category of the current item in the list.

`RSSReader.item.creator` - (string) Creator of the current item in the list.

`RSSReader.item.guid` - (string) GUID of the current item in the list.

`RSSReader.item.link` - (string) Link of the current item in the list.

`RSSReader.item.pubDate` - (string) Publication date of the current item in the list.

`RSSReader.item.description` - (string) Description of the current item in the list.

------

### TO-DO

- image tag support
- itunes tag support for podcasts
- media tag support
- comments tag support
- HTML tag formatting
- Create a demo scene with pre-made rss feeds
- Test backwards compatability
- refresh method
- set limit of items to fetch
- Rich text support
- realtime editor preview