# EpicNews
Application for collecting the most idiotic news titles

http://epic-news.com/

# API documentation

## Get list of news
### Request
```
GET: http://epic-news.com/api/newslist/get?count=5&start=0
```
where: 
* **count** - getting news count
* **start** - starting position

In this exaple API returns 5 news titles starting from position 0. All news sorted by publication date starting from the newest.

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
         "Title":"Исчезнувшего кенийского таксиста нашли пьяным в день его похорон",
         "LinkToArticle":"https://lenta.ru/news/2017/04/04/dead/",
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
   "Title":"Харьковчанин избил женщину за пение под караоке",
   "LinkToArticle":"http://newsroom.kh.ua/news/harkovchanin-izbil-zhenshchinu-za-penie-pod-karaoke-sud-vynes-prigovor",
   "LanguageId":2,
   "Id":1
}
```
