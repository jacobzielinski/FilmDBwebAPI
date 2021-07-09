/// <reference path="../knockout.d.ts" />
/// <reference path="../jquery.d.ts" />
/// <reference path="../Interfaces/HomeInterfaces.ts" />
/// <reference path="../Repositories/HomeRepository.ts" />

module TT {

    export interface IAjaxResult<T> /* JQuery.jqXHR<any> */ { 
        message: string;
        succeeded: boolean;
        warning: boolean;
        data: T;
    }

    export interface IFlim {
        id: number;
        userId: number;
        name: string;
        yearOfProduction: string;
        userNotes: string;
        isDeleted: boolean;
    }

}