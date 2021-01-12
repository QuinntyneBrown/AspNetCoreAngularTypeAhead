import { OverlayRef } from '@angular/cdk/overlay';
import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { switchMap, takeUntil, tap } from 'rxjs/operators';
import { ToDosService } from '../to-dos.service';

@Component({
  selector: 'app-complete-to-do',
  templateUrl: './complete-to-do.component.html',
  styleUrls: ['./complete-to-do.component.scss']
})
export class CompleteToDoComponent implements OnInit, OnDestroy {

  private readonly _destoyed: Subject<void> = new Subject();

  public get destroyed(): Subject<void> { return this._destoyed; }

  @Input() public toDoId: string = "";

  constructor(private _toDosService: ToDosService, private _overlayRef: OverlayRef) { }

  ngOnInit(): void {
    this._toDosService.getById({ toDoId: this.toDoId})
    .pipe(
      takeUntil(this._destoyed),
      switchMap(toDo => {
        return this._toDosService.complete({ toDoId: toDo.toDoId })
      }),
      tap(x => this._overlayRef.dispose())
    )
    .subscribe()
  }

  ngOnDestroy() {
    this._destoyed.next();
    this._destoyed.complete();
  }

}
