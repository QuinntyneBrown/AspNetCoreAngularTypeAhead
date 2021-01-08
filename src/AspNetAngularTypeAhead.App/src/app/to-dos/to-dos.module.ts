import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateToDoComponent } from './create-to-do/create-to-do.component';
import { CompleteToDoComponent } from './complete-to-do/complete-to-do.component';
import { ToDoListComponent } from './to-do-list/to-do-list.component';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from '@shared';



@NgModule({
  declarations: [CreateToDoComponent, CompleteToDoComponent, ToDoListComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    SharedModule
  ]
})
export class ToDosModule { }
