/// <reference path="../knockout.d.ts" />
/// <reference path="../jquery.d.ts" />
/// <reference path="../Interfaces/HomeInterfaces.ts" />
/// <reference path="../Repositories/HomeRepository.ts" />
/// <reference path="../ModelInterfaces/ModelInterfaces.ts" />
var TT;
(function (TT) {
    var HomeViewModel = /** @class */ (function () {
        function HomeViewModel(repository) {
            var _this = this;
            this.repository = repository;
            this.textTest = ko.observable("HELLO WORLD");
            this.films = ko.observableArray();
            this.film = ko.observable();
            this.getFilmForUser = function () {
                _this.repository.getSingleForUser()
                    .done(function (result) {
                    if (result.succeeded)
                        _this.film(result.data);
                    else {
                    }
                });
            };
            this.GetAllFilmsForUser = function () {
                _this.repository.getListForUser()
                    .done(function (result) {
                    if (result.succeeded)
                        _this.film(result.data);
                    else {
                    }
                });
            };
            this.textTest();
        }
        return HomeViewModel;
    }());
    TT.HomeViewModel = HomeViewModel;
})(TT || (TT = {}));
//# sourceMappingURL=HomeViewModel.js.map