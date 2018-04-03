import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Computer } from '../computer';
import { ComputerService } from '../computer.service';

@Component({
  selector: 'app-computer-detail',
  templateUrl: './computer-detail.component.html',
  styleUrls: ['./computer-detail.component.css']
})
export class ComputerDetailComponent implements OnInit {
  @Input() computer: Computer;

  //public now: Date = new Date();

  constructor(
    private route: ActivatedRoute,
    private computerService: ComputerService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getComputer();
  }

  getComputer(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.computerService.getComputer(id)
      .subscribe(computer => this.computer = computer);
  }

  save(): void {
    console.log(this.computer);
    this.computerService.updateComputer(this.computer)
      .subscribe(() => this.goBack());
  }

  delete(): void {
    this.computerService.deleteComputer(this.computer).subscribe(() => this.goBack());
  }

  goBack(): void {
    this.location.back();
  }
}
