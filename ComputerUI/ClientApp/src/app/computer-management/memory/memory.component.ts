import { Component, OnInit } from '@angular/core';

import { Memory } from '../computer';
import { MemoryService } from './memory.service';

@Component({
  selector: 'app-memory',
  templateUrl: './memory.component.html',
  styleUrls: ['./memory.component.css']
})
export class MemoryComponent implements OnInit {

  memorys: Memory[];

  constructor(private memoryService: MemoryService) { }

  ngOnInit() {
    this.getMemorys();
  }

  getMemorys(): void {
    this.memoryService.getMemorys()
      .subscribe(memorys => this.memorys = memorys);
  }

  delete(memory: Memory): void {
    this.memorys = this.memorys.filter(h => h !== memory);
    this.memoryService.deleteMemory(memory).subscribe();
  }

}
