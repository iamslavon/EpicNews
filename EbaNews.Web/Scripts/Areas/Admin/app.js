angular.module("admin", ["ngNotify", "newsCount", "suggestedNewsCount"])
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