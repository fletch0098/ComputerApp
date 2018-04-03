import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { FormsModule, NgModel } from '@angular/forms'; // <-- NgModel lives here

import { HttpClientModule } from '@angular/common/http';

import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService } from './in-memory-data.service';


import { ComputerManagementComponent } from '../computer-management/computer-management.component';
import { ComputersComponent } from '../computer-management/computers/computers.component';
import { ComputerDetailComponent } from '../computer-management/computer-detail/computer-detail.component';
import { ComputerService } from './computer.service';
import { MessageService } from './message.service';
import { MessagesComponent } from './messages/messages.component';

import { ComputerManagementRoutingModule } from './computer-management-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ComputerSearchComponent } from './computer-search/computer-search.component';
import { AddComputerComponent } from './add-computer/add-computer.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ComputerManagementRoutingModule,
    HttpClientModule,

    // The HttpClientInMemoryWebApiModule module intercepts HTTP requests
    // and returns simulated server responses.
    // Remove it when a real server is ready to receive requests.
    //HttpClientInMemoryWebApiModule.forRoot(
    //  InMemoryDataService, { dataEncapsulation: false }
    //)
  ],
  declarations: [
    ComputerManagementComponent,
    ComputersComponent,
    ComputerDetailComponent,
    MessagesComponent,
    DashboardComponent,
    ComputerSearchComponent,
    AddComputerComponent,
  ],
  providers: [ComputerService, MessageService]
})
export class ComputerManagementModule { }
