# EpicNews
Application for collecting the most idiotic news titles

http://epic-news.com/

# API documentation

## Get list of news
### Request
```
GET: http://epic-news.com/api/newslist/get?count=5&start=0&culture=en
```
Parameters: 
* **count** (number) - getting news count
* **start** (number) - starting position
* **culture** (string, optional) - news language

Available cultures:
* 'en' (English)
* 'ru' (Russian)
* 'uk' (Ukrainian)

Parameter **culture** is optional in request. If you don't pass this parameter, culture will be selected by default value - **ru**. All news sorted by publication date starting from the newest. Number of news you can get per one request are limited to 10.

### Response
API returns response in JSON format 
```
{  
   "Total":163,
   "Data":[  
      {  
         "Language":{  
            "Name":"RUS",
            "Culture":"ru",
            "Id":2
         },
         "PublicationDate":"\/Date(1521623787507)\/",
         "Online":true,
         "ShareCount":0,
         "SocialNetworksPublished":true,
         "Title":"Crazy news title will be here",
         "LinkToArticle":"http://url-to-news",
         "LanguageId":2,
         "Id":4154
      }
   ]
}
```
where **Total** - total news count in DB by language (RUS)

## Get particular news
### Request
```
GET: http://epic-news.com/api/news/get?id=1
```
where **id** - news id

### Response
```
{  
   "Language":{  
      "Name":"RUS",
      "Culture":"ru",
      "Id":2
   },
   "PublicationDate":"\/Date(1511906695893)\/",
   "Online":true,
   "ShareCount":0,
   "SocialNetworksPublished":true,
   "Title":"Crazy news title will be here",
   "LinkToArticle":"http://url-to-news",
   "LanguageId":2,
   "Id":1
}
```
