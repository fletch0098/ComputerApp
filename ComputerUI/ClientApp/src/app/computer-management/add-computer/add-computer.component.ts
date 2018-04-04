import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Computer } from '../computer';
import { ComputerService } from '../computer.service';

@Component({
  selector: 'app-add-computer',
  templateUrl: './add-computer.component.html',
  styleUrls: ['./add-computer.component.css']
})
export class AddComputerComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private computerService: ComputerService,
    private location: Location) { }

  ngOnInit() {
  }

  goBack(): void {
    this.location.back();
  }

  add(configuracionName: string, memoryId: number, processor: string, hardDrive: string): void {

    configuracionName = configuracionName.trim();
    memoryId = memoryId;
    processor = processor.trim();
    hardDrive = hardDrive.trim();


    if (!configuracionName) { return; }
    if (!memoryId) { return; }
    if (!processor) { return; }
    if (!hardDrive) { return; }

    //var computer: Computer;
    //computer.configuracionName = configuracionName;
    //computer.hardDrive = hardDrive;
    //computer.memoryId = memoryId;
    //computer.processor = processor;
    
    this.computerService.addComputer({ configuracionName, hardDrive, memoryId, processor} as Computer)
      .subscribe(() => this.goBack());
  }

}
