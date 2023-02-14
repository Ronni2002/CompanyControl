import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
const apiUrl = environment.apiUrl;

export class BaseService<T> {
    constructor(private httpclient: HttpClient, public enpoint: string){
        this.enpoint = enpoint
    }

    getAll() : Observable<T[]> {
        return this.httpclient.get<T[]>(`${apiUrl}/${this.enpoint}`);
    }

    getById(id: string) : Observable<T> {
        return this.httpclient.get<T>(`${ apiUrl }/${this.enpoint}/${ id }`);
    }

    post(body: T) : Observable<T> {
        return this.httpclient.post<T>(`${apiUrl}/${this.enpoint}`, body);
    }

    update(id: number, body: T) : Observable<T> {
        return this.httpclient.put<T>(`${ apiUrl }/${this.enpoint}/${ id }`, body);
    }

    delete(id: string) : Observable<T> {
        return this.httpclient.delete<T>(`${ apiUrl }/${this.enpoint}/${ id }`);
    }
}