import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddMemoryComponent } from './add-memory/add-memory.component';
import { MemoryDetailComponent } from './memory-detail/memory-detail.component';
import { MemoryComponent } from './memory.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [AddMemoryComponent, MemoryDetailComponent, MemoryComponent]
})
export class MemoryModule { }
