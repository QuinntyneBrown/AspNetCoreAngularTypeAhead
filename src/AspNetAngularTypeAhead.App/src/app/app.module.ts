import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from '@shared';
import { ToDosModule } from './to-dos/to-dos.module';
import { baseUrl } from '@core/constants';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    ToDosModule,
    SharedModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [
    { provide: baseUrl, useValue: "https://localhost:5001/"}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
