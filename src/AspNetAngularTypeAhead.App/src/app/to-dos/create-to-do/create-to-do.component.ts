import { OverlayRef } from '@angular/cdk/overlay';
import { Component, OnInit } from '@angular/core';
import { ToDosService } from '../to-dos.service';

@Component({
  selector: 'app-create-to-do',
  templateUrl: './create-to-do.component.html',
  styleUrls: ['./create-to-do.component.scss']
})
export class CreateToDoComponent implements OnInit {

  constructor(private toDosService: ToDosService, private overlayRef: OverlayRef) { }

  ngOnInit(): void {

  }

}
