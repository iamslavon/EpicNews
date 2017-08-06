var ViewModel = function () {
    var self = this;
    self.newsList = ko.observableArray();
    self.total = ko.observable(0);
    self.page = ko.observable(1);
    self.pageSize = 10;
    self.loading = ko.observable(false);
    self.totalPages = ko.computed(function () {
        return Math.ceil(self.total() / self.pageSize);
    });

    self.news = function (id, title, linkToArticle, publicationDate, online, language) {
        this.Id = id;
        this.Title = ko.observable(title);
        this.LinkToArticle = ko.observable(linkToArticle);
        this.PublicationDate = moment(publicationDate).format('DD.MM.YYYY');
        this.Online = ko.observable(online);
        this.Language = language;
    };

    self.language = function (id, name) {
        this.Id = id;
        this.Name = name;
    };

    self.map = function (data) {
        self.newsList([]);

        for (var i = 0; i < data.length; i++) {
            var news = new self.news(
                data[i].Id,
                data[i].Title,
                data[i].LinkToArticle,
                data[i].PublicationDate,
                data[i].Online,
                new self.language(data[i].Language.Id, data[i].Language.Name));

            self.newsList.push(news);
        }
    };

    self.startLoading = function () {
        self.loading(true);
    };

    self.stopLoading = function () {
        self.loading(false);
    };

    self.getNews = function () {
        self.startLoading();

        var request = {
            page: self.page,
            pageSize: self.pageSize
        };

        $.get("/mngmnt/news/get", request, function (response) {
            self.map(response.Data);
            self.total(response.Total);
            self.stopLoading();
        });
    };

    self.switchOnlineStatus = function (news) {
        var request = {
            newsId: news.Id,
            online: !news.Online()
        };

        $.post("/mngmnt/news/online/switch", request, function () {
            news.Online(!news.Online());
        });
    };

    self.setPage = function (data, event, page) {
        self.page(page);
        self.getNews();
    };

    self.getNews();
};

ko.applyBindings(new ViewModel());