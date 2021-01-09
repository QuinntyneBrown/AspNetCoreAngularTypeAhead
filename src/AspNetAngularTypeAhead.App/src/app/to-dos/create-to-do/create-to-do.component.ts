import { OverlayRef } from '@angular/cdk/overlay';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToDosService } from '../to-dos.service';

@Component({
  selector: 'app-create-to-do',
  templateUrl: './create-to-do.component.html',
  styleUrls: ['./create-to-do.component.scss']
})
export class CreateToDoComponent implements OnInit {

  public form = new FormGroup({
    title: new FormControl(null, [Validators.required])
  });
  
  constructor(private toDosService: ToDosService, private _overlayRef: OverlayRef) { }

  ngOnInit(): void {

  }

  cancel(): void {
    this._overlayRef.dispose();
  }
}
