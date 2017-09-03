var ViewModel = function () {
    var self = this;

    self.newsList = ko.observableArray();
    self.languages = ko.observableArray();

    self.total = ko.observable(0);
    self.page = ko.observable(1);
    self.pageSize = 10;
    self.loading = ko.observable(false);
    self.totalPages = ko.computed(function () {
        return Math.ceil(self.total() / self.pageSize);
    });

    self.newsModel = function (id, title, linkToArticle, publicationDate, online, language) {
        this.Id = id;
        this.Title = ko.observable(title);
        this.LinkToArticle = ko.observable(linkToArticle);
        this.PublicationDate = moment(publicationDate).format('DD.MM.YYYY');
        this.Online = ko.observable(online);
        this.Language = language;
    };

    self.news = ko.observable(new self.newsModel());

    self.language = function (id, name) {
        this.Id = id;
        this.Name = name;
    };

    self.mapNews = function (data) {
        self.newsList([]);

        for (var i = 0; i < data.length; i++) {
            var news = new self.newsModel(
                data[i].Id,
                data[i].Title,
                data[i].LinkToArticle,
                data[i].PublicationDate,
                data[i].Online,
                new self.language(data[i].Language.Id, data[i].Language.Name)
            );
            self.newsList.push(news);
        }
    };

    self.mapLanguages = function (data) {
        self.languages([]);

        for (var i = 0; i < data.length; i++) {
            var language = new self.language(
                data[i].Id,
                data[i].Name);

            self.languages.push(language);
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
            self.mapNews(response.Data);
            self.total(response.Total);
            self.stopLoading();
        });
    };

    self.getLanguages = function () {
        $.get("/mngmnt/languages/get", function (response) {
            self.mapLanguages(response);
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

    self.addNews = function () {
        var data = ko.toJS(self.news);

        $.post("/mngmnt/news/add", data, function (response) {
            $('#add-modal').modal('hide');
            self.news(new self.newsModel());
            self.getNews();
        });


    };

    self.addNewsValidation = {
        titleInvalid: function () {
            return (
                self.news().Title() == undefined ||
                self.news().Title().length < 3
                );
        },

        linkInvalid: function () {
            return (
                self.news().LinkToArticle() == undefined ||
                self.news().LinkToArticle().length < 3
            );
        },

        formInvalid: function () {
            return (this.titleInvalid() || this.linkInvalid());
        }
    };

    self.setPage = function (data, event, page) {
        self.page(page);
        self.getNews();
    };

    self.getNews();
    self.getLanguages();
};

ko.applyBindings(new ViewModel());