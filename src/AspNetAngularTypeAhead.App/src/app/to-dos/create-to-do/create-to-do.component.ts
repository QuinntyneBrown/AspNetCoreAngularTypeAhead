import { OverlayRef } from '@angular/cdk/overlay';
import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { takeUntil, tap } from 'rxjs/operators';
import { ToDo } from '../to-do';
import { ToDosService } from '../to-dos.service';

@Component({
  selector: 'app-create-to-do',
  templateUrl: './create-to-do.component.html',
  styleUrls: ['./create-to-do.component.scss']
})
export class CreateToDoComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();

  public get destroyed(): Subject<void> { return this._destroyed; }

  @Output() public saved: EventEmitter<ToDo> = new EventEmitter();

  public form = new FormGroup({
    title: new FormControl(null, [Validators.required])
  });
  
  constructor(private _toDosService: ToDosService, private _overlayRef: OverlayRef) { }

  public save() {
    const toDo = { title: this.form.value.title };

    this._toDosService.create({ toDo })
    .pipe(
      takeUntil(this._destroyed), 
      tap(x => this.saved.next( toDo )),
      tap(x => this._overlayRef.dispose())   
    ).subscribe();
  }

  cancel(): void {
    this._overlayRef.dispose();
  }

  ngOnDestroy() {
    this._destroyed.next();
    this._destroyed.complete();
  }
}
