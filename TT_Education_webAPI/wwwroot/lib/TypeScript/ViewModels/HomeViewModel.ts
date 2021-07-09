/// <reference path="../knockout.d.ts" />
/// <reference path="../jquery.d.ts" />
/// <reference path="../Interfaces/HomeInterfaces.ts" />
/// <reference path="../Repositories/HomeRepository.ts" />
/// <reference path="../ModelInterfaces/ModelInterfaces.ts" />





module TT {

    export class HomeViewModel {

        public textTest = ko.observable<string>("HELLO WORLD");
        public films = ko.observableArray<IFlim>();
        public film = ko.observable<IFlim>();

        public getFilmForUser = () => {
            this.repository.getSingleForUser()
                .done((result: IAjaxResult<IFlim>) => {
                    if (result.succeeded)
                        this.film(result.data);
                    else {

                    }
                })
        }

        public GetAllFilmsForUser = () => {
            this.repository.getListForUser()
                .done((result: IAjaxResult<IFlim>) => {
                    if (result.succeeded)
                        this.film(result.data);
                    else {

                    }
                })
        }

        constructor(public repository: IApiRepository) {
            this.textTest();

        }

    }
}