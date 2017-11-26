angular.module("admin", ["ngNotify", "newsCount"])
    .run(function (ngNotify) {
        ngNotify.config({
            theme: "pure",
            position: "bottom",
            duration: 5000,
            sticky: false,
            button: true,
            html: false
        });
    }
);