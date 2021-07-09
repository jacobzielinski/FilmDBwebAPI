/// <reference path="../knockout.d.ts" />
/// <reference path="../jquery.d.ts" />

module TT {

    export interface IApiRepository {
        getListForUser(): JQueryXHR;
        getSingleForUser(): JQueryXHR;
    }
    
}