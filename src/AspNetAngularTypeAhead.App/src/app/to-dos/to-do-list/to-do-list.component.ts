import { Component, Injector, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { DialogService } from '@shared/dialog.service';
import { BehaviorSubject, Subject } from 'rxjs';
import { takeUntil, tap } from 'rxjs/operators';
import { CompleteToDoComponent } from '../complete-to-do/complete-to-do.component';
import { CreateToDoComponent } from '../create-to-do/create-to-do.component';
import { ToDo } from '../to-do';
import { ToDosService } from '../to-dos.service';

@Component({
  selector: 'app-to-do-list',
  templateUrl: './to-do-list.component.html',
  styleUrls: ['./to-do-list.component.scss']
})
export class ToDoListComponent implements OnInit, OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();
  
  public toDos$: BehaviorSubject<ToDo[]> = new BehaviorSubject([] as ToDo[]);

  dataSource: MatTableDataSource<ToDo> = new MatTableDataSource([] as ToDo[]);

  public displayedColumns:string[] = [
    "title",
    "actions"
  ];

  constructor(private _toDosService: ToDosService, private _dialogService: DialogService) { }

  ngOnInit(): void {
    this._toDosService.get()
    .pipe(
      takeUntil(this._destroyed),
      tap(x => this.toDos$.next(x))
    ).subscribe();
  }

  public create() {
    this._dialogService.open<CreateToDoComponent>(CreateToDoComponent);
  }

  public complete(toDoId:string) {    
    const component = this._dialogService.open<CompleteToDoComponent>(CompleteToDoComponent);
    component.toDoId = toDoId;
  }

  ngOnDestroy(): void {
    this._destroyed.next();
    this._destroyed.complete();
  }
}
