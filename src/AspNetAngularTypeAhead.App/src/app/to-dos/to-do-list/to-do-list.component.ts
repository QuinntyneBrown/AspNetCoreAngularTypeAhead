import { ChangeDetectionStrategy, Component, OnDestroy, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { DialogService } from '@shared/dialog.service';
import { BehaviorSubject, combineLatest, Observable, Subject } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';
import { CompleteToDoComponent } from '../complete-to-do/complete-to-do.component';
import { CreateToDoComponent } from '../create-to-do/create-to-do.component';
import { ToDo } from '../to-do';
import { ToDosService } from '../to-dos.service';

@Component({
  selector: 'app-to-do-list',
  templateUrl: './to-do-list.component.html',
  styleUrls: ['./to-do-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ToDoListComponent implements OnDestroy, OnInit  {
  private readonly _destroyed: Subject<void> = new Subject();

  public toDo$: Observable<MatTableDataSource<ToDo>> = this._toDosService
  .get()
  .pipe(
    map(x => new MatTableDataSource(x))
  )

  public vm$:BehaviorSubject<any> = new BehaviorSubject(null);

  public dataSource$: BehaviorSubject<MatTableDataSource<ToDo>> = new BehaviorSubject(null);

  public refresh$ = this.toDo$.pipe(
    map(dataSource => this.vm$.next({ dataSource }))
  );

  public displayedColumns:string[] = [
    "title",
    "actions"
  ];

  constructor(private _toDosService: ToDosService, private _dialogService: DialogService) { }

  ngOnInit() {
    this.refresh$
    .pipe(
      takeUntil(this._destroyed),
    )
    .subscribe();
  }

  public create() {
    const component = this._dialogService.open<CreateToDoComponent>(CreateToDoComponent)
    .destroyed
    .pipe(
      takeUntil(this._destroyed),
      switchMap(x => this.refresh$),
    ).subscribe();
  }

  public complete(toDoId:string) {    
    const component = this._dialogService.open<CompleteToDoComponent>(CompleteToDoComponent);
    
    component.toDoId = toDoId;

    component.destroyed
    .pipe(
      takeUntil(this._destroyed),
      switchMap(x => this.refresh$),
    ).subscribe();
  }

  ngOnDestroy() {
    this._destroyed.next();
    this._destroyed.complete();    
  }
}
