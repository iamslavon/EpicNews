var ViewModel = function () {
    var self = this;
    self.users = ko.observableArray();
    self.loading = ko.observable(false);

    self.user = function (id, name, email, roles) {
        this.Id = id;
        this.Name = name;
        this.Email = email;
        this.Roles = ko.observableArray(roles);
    };

    self.map = function (data) {
        for (var i = 0; i < data.length; i++) {
            var user = new self.user(data[i].Id, data[i].Name, data[i].Email, data[i].Roles);
            self.users.push(user);
        }
    };

    self.startLoading = function () {
        self.loading(true);
    };

    self.stopLoading = function () {
        self.loading(false);
    };

    self.isInRole = function (user, role) {
        return user.Roles.indexOf(role) !== -1;
    };

    self.getUsers = function () {
        self.startLoading();
        $.get("/mngmnt/users/get", function (response) {
            self.map(response);
            self.stopLoading();
        });
    };

    self.switchAdminRole = function (user) {
        self.switchRole(user, "admin");
    };

    self.switchOwnerRole = function (user) {
        self.switchRole(user, "owner");
    };

    self.switchRole = function (user, role) {
        var data = {
            UserId: user.Id,
            Role: role
        };

        $.post("/mngmnt/users/role/switch", data, function (response) {
            user.Roles(response);
        });
    };

    self.getUsers();
};

ko.applyBindings(new ViewModel());