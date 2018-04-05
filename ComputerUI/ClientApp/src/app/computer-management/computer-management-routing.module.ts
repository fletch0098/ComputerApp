import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ComputerManagementComponent } from '../computer-management/computer-management.component';
import { ComputersComponent } from '../computer-management/computers/computers.component';
import { ComputerDetailComponent } from '../computer-management/computer-detail/computer-detail.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AddComputerComponent } from './add-computer/add-computer.component';
import { Memory } from './computer';
import { AddMemoryComponent } from './memory/add-memory/add-memory.component';
import { MemoryDetailComponent } from './memory/memory-detail/memory-detail.component';
import { MemoryComponent } from './memory/memory.component';

const computerManagementRoutes: Routes = [
  {
    path: '',
    component: ComputerManagementComponent,
    children: [
      {
        path: '',
        children: [
          { path: 'add-computer', component: AddComputerComponent },
          { path: 'computers', component: ComputersComponent },
          { path: 'computers/detail/:id', component: ComputerDetailComponent },
          { path: 'dashboard', component: DashboardComponent },
          { path: 'memory', component: MemoryComponent },
          { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
        ]
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(computerManagementRoutes)
  ],
  exports: [
    RouterModule
  ]
})

export class ComputerManagementRoutingModule { }
