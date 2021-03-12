import { Component, OnInit } from '@angular/core';
import { DashboardBaseComponent } from '@project-manager/component-base';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent extends DashboardBaseComponent implements OnInit {

  constructor() {
    super()
  }

  ngOnInit(): void {
  }

}
