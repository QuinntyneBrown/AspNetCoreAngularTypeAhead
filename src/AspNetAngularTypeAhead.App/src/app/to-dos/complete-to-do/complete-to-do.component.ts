import { Component, Input, OnInit } from '@angular/core';
import { ToDosService } from '../to-dos.service';

@Component({
  selector: 'app-complete-to-do',
  templateUrl: './complete-to-do.component.html',
  styleUrls: ['./complete-to-do.component.scss']
})
export class CompleteToDoComponent implements OnInit {

  @Input() public toDoId: string = "";

  constructor(private _toDoService: ToDosService) { }

  ngOnInit(): void {
  }

}
