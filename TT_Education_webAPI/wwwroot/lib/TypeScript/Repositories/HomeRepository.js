/// <reference path="../knockout.d.ts" />
/// <reference path="../jquery.d.ts" />
/// <reference path="../Interfaces/HomeInterfaces.ts" />
var TT;
(function (TT) {
    var HomeRepository = /** @class */ (function () {
        function HomeRepository() {
        }
        HomeRepository.prototype.getListForUser = function () {
            return $.get("http://localhost:36435/api/FilmModels");
        };
        HomeRepository.prototype.getSingleForUser = function () {
            return $.get("http://localhost:44354/api/FilmModel/5");
        };
        return HomeRepository;
    }());
    TT.HomeRepository = HomeRepository;
})(TT || (TT = {}));
//# sourceMappingURL=HomeRepository.js.map