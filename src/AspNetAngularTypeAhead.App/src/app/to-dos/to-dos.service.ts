import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ToDo } from './to-do';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl } from '@core/constants';

@Injectable({
  providedIn: 'root'
})
export class ToDosService {

  constructor(
    @Inject(baseUrl) private _baseUrl: string,
    private _client: HttpClient
  ) { }

  public get(): Observable<ToDo[]> {
    return this._client.get<{ toDos: ToDo[] }>(`${this._baseUrl}api/toDos`)
      .pipe(
        map(x => x.toDos)
      );
  }

  public getById(options: { toDoId: string }): Observable<ToDo> {
    return this._client.get<{ toDo: ToDo }>(`${this._baseUrl}api/toDos/${options.toDoId}`)
      .pipe(
        map(x => x.toDo)
      );
  }

  public remove(options: { toDo: ToDo }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/toDos/${options.toDo.toDoId}`);
  }

  public create(options: { toDo: ToDo }): Observable<{ id: number }> {
    return this._client.post<{ id: number }>(`${this._baseUrl}api/toDos`, { toDo: options.toDo });
  }  

  public complete(options: { toDoId?: string }): Observable<{ id: number }> {
    return this._client.put<{ id: number }>(`${this._baseUrl}api/toDos`, { toDoId: options.toDoId });
  }  
}
