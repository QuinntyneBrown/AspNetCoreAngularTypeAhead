import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';
import { Component, OnDestroy, OnInit } from '@angular/core';
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

  constructor(private _toDosService: ToDosService, private _overlay: Overlay) { }

  private _destroyed: Subject<void> = new Subject();

  public toDos$: BehaviorSubject<ToDo[]> = new BehaviorSubject([] as ToDo[]);

  public displayedColumns:string[] = [
    "title"
  ];

  ngOnInit(): void {
    this._toDosService.get()
    .pipe(
      takeUntil(this._destroyed),
      tap(x => this.toDos$.next(x))
    ).subscribe();
  }

  dataSource:ToDo[] = [];
  

  ngOnDestroy(): void {
    this._destroyed.next();
    this._destroyed.complete();
  }

  public create() {
    this.attach<CreateToDoComponent>(new ComponentPortal(CreateToDoComponent));
  }

  public complete() {
    this.attach<CompleteToDoComponent>(new ComponentPortal(CompleteToDoComponent));
  }

  private attach<T>(componentPortal: ComponentPortal<T>): OverlayRef {
    const positionStrategy = this._overlay.position()
    .global()
    .centerHorizontally()
    .centerVertically();

    const overlayRef = this._overlay.create({
      hasBackdrop: true,
      positionStrategy
    });

    overlayRef.attach(componentPortal);

    return overlayRef;
  }
}
