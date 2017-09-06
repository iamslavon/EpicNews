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

    self.newsModel = function () {
        this.Id = 0;
        this.Title = ko.observable();
        this.LinkToArticle = ko.observable();
        this.PublicationDate = moment().format('DD.MM.YYYY');
        this.Online = ko.observable();
        this.Language = null;
    };

    self.news = ko.observable(new self.newsModel());
    self.editingNews = ko.observable(new self.newsModel());

    self.mapNews = function (data) {
        self.newsList([]);

        for (var i = 0; i < data.length; i++) {
            data[i].PublicationDate = moment(data[i].PublicationDate).format('DD.MM.YYYY');
            var news = ko.mapping.fromJS(data[i]);
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
            self.mapNews(response.Data);
            self.total(response.Total);
            self.stopLoading();
        });
    };

    self.getLanguages = function () {
        $.get("/mngmnt/languages/get", function (response) {
            self.languages(response);
        });
    };

    self.setPage = function (data, event, page) {
        self.page(page);
        self.getNews();
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

    // validation
    self.isInvalidField = function (field) {
        return (
            field === null ||
            field === undefined ||
            field.length < 3
        );
    };

    self.addNewsValidation = {
        titleInvalid: function () {
            return self.isInvalidField(self.news().Title());
        },

        linkInvalid: function () {
            return self.isInvalidField(self.news().LinkToArticle());
        },

        formInvalid: function () {
            return this.titleInvalid() || this.linkInvalid();
        }
    };

    self.editNewsValidation = {
        titleInvalid: function () {
            return self.isInvalidField(self.editingNews().Title());
        },

        linkInvalid: function () {
            return self.isInvalidField(self.editingNews().LinkToArticle());
        },

        formInvalid: function () {
            return this.titleInvalid() || this.linkInvalid();
        }
    };

    self.openEditModal = function (news) {
        var copy = ko.mapping.fromJS(ko.toJS(news));
        self.editingNews(copy);
        $('#edit-modal').modal('show');
    };

    self.editNews = function () {
        var data = ko.toJS(self.editingNews);

        $.post("/mngmnt/news/edit", data, function () {
            $('#edit-modal').modal('hide');
            self.getNews();
        });
    };

    self.getNews();
    self.getLanguages();
};

ko.applyBindings(new ViewModel());